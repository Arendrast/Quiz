using System;
using UnityEngine;

[Serializable]
public class Question
{
    [field: SerializeField] public string Content { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; set; }

    public void SetSprite(Sprite sprite) => Sprite = sprite;
}