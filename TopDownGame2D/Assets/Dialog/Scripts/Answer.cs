using System;
using UnityEngine;

namespace Dialog
{
    [Serializable]
    public class Answer
    {
        [SerializeField] private string _text;
        [SerializeField] private Dialog _nextDialog;

        public string Text => _text;
        public Dialog NextDialog => _nextDialog;
    }
}
