using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QestionWithAnswers
{
    [field: SerializeField] public List<string> Answers { get; private set; }
    [field: SerializeField] public int IndexRightAnswer { get; private set; }
    [field: SerializeField] public Question Question { get; private set; }
}