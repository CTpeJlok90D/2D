using UnityEngine;
using UnityEngine.Events;

namespace Dialog
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private Dialog _dialog;
        [SerializeField] private UnityEvent<Dialog> _dialogChanged;
        private Dialog _currentDialog;

        public void Talk()
        {
            _currentDialog = _dialog;
            _dialogChanged.Invoke(_currentDialog);
        }

        public void Answer(int answerIndex)
        {
            _currentDialog = _currentDialog.Answers[answerIndex].Dialog;
            _dialogChanged.Invoke(_currentDialog);
        }
    }
}