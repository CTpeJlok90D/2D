using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _answerText;
    [SerializeField] private Button _button;

    public void Awake()
    {
        _button.onClick.AddListener(InputHandler.Singletone.Dialog.Enable);
    }

    public AnswerView Init(string answerText, Action onClick)
    {
        _answerText.text = answerText;
        _button.onClick.AddListener(() => { onClick.Invoke(); });
        return this;
    }
}
