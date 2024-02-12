using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] private List<Result> _results = new List<Result>();
    [SerializeField] private TMP_Text _descriptionText, _rightAnswerText;
    [SerializeField] private Image _image;

    public void OnOpen(int rightAnswerNumber, int generalQuestionsNumber)
    {
        _rightAnswerText.text = $"{rightAnswerNumber}/{generalQuestionsNumber}";
        GetSuitableResult(rightAnswerNumber);
    }

    private void GetSuitableResult(int rightAnswerNumber)
    {
        foreach (var result in _results)
        {
            if (IsDisplayResult(result, rightAnswerNumber))
            {
                DisplayResult(result);
                break;
            }
        }
    }

    private bool IsDisplayResult(Result result, int rightAnswerNumber) =>
        rightAnswerNumber >= result.RequiredRightAnswersNumber;
    private void DisplayResult(Result result)
    {
        _descriptionText.text = result.Content;
        _image.sprite = result.Sprite;
    }
}