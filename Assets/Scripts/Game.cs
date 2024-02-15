using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private List<QestionWithAnswers> _questionsWithAnswers = new List<QestionWithAnswers>();
    [SerializeField] private List<Button> _answerButtons;
    [SerializeField] private List<TMP_Text> _answerTexts = new List<TMP_Text>();
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TMP_Text _questionText, _counterQuestionText;
    [SerializeField] private Image _questionImage;
    [SerializeField] private ResultMenu _resultMenuPrefab;

    [SerializeField] private List<RectTransform> _objectsForOffOnShowResultMenu;
    //[SerializeField] private Sprite[] _sprites;
    private string _currentAnswer;
    private QestionWithAnswers CurrentQuestion => _questionsWithAnswers[_currentQuestionNumber];
    private int _currentQuestionNumber;
    private int _rightAnswerCounter;

    // private void OnValidate()
    // {
    //     for (var i = 0; i < _sprites.Length; i++)
    //     {
    //         if (_sprites[i])
    //             _questionsWithAnswers[i].Question.Sprite = _sprites[i];
    //     }
    // }

    private void Start() => Initialize();

    private void Initialize()
    {
        SetAnswers();
        SetQuestionText();
        SetQuestionImageSprite();
        UpdateQuestionCounter();
    }

    private void UpdateQuestionCounter() => _counterQuestionText.text = $"{_currentQuestionNumber + 1}/{_questionsWithAnswers.Count}";
    private bool IsLastQuestion() => CurrentQuestion == _questionsWithAnswers[^1];

    private void OffObjects() => _objectsForOffOnShowResultMenu.ForEach(obj => obj.gameObject.SetActive(false));

    private void OnClickAnswerButton()
    {
        if (IsLastQuestion())
        {
            OpenResultMenu();
            OffObjects();
            return;
        }
        
        HandleInputAnswer();
        IncreaseCurrentQuestionNumber();
        SetAnswers();
        SetQuestionText();
        SetQuestionImageSprite();
        UpdateQuestionCounter();
    }

    private void OpenResultMenu()
    {
        var resultMenu = Instantiate(_resultMenuPrefab, _canvas.transform);
        resultMenu.OnOpen(_rightAnswerCounter, _questionsWithAnswers.Count);
    }

    private void HandleInputAnswer()
    {
        if (_currentAnswer == CurrentQuestion.Answers[CurrentQuestion.IndexRightAnswer])
        {
            _rightAnswerCounter++;
        }
    }

    private void SetAnswerOnButton(Button button, string answer)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => SetCurrentAnswer(answer));
        button.onClick.AddListener(OnClickAnswerButton);
    }

    private void SetCurrentAnswer(string answer) => _currentAnswer = answer;

    private void IncreaseCurrentQuestionNumber() => _currentQuestionNumber++;

    private void SetQuestionImageSprite() => _questionImage.sprite = CurrentQuestion.Question.Sprite;

    private void SetQuestionText() => _questionText.text = CurrentQuestion.Question.Content;

    private void SetAnswers()
    {
        for (var i = 0; i < _answerTexts.Count; i++)
        {
            var answerText = _answerTexts[i];
            var answerButton = _answerButtons[i];
            var answer = CurrentQuestion.Answers[i];
            answerText.text = answer;
            SetAnswerOnButton(answerButton, answer);
        }
    }
}