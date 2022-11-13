using System;
using UnityEngine;

namespace Dialog
{
    [CreateAssetMenu()]
    public class Answer : ScriptableObject
    {
        [SerializeField] private string _text;
        [SerializeField] private Dialog _nextDialog;

        public string Text => _text;
        public Dialog NextDialog => _nextDialog;
    }
}
