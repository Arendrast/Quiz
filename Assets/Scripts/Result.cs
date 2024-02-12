using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Result
{
    [field: SerializeField] public int RequiredRightAnswersNumber { get; private set; }
    [field: SerializeField] public string Content { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}