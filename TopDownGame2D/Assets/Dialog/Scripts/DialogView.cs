using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dialog
{
    public class DialogView : MonoBehaviour
    {
        [SerializeField] private GameObject _dialogWindow;
        [SerializeField] private TMP_Text _dialogTextPlace;
        [SerializeField] private Transform _answerContainer;
        [SerializeField] private AnswerView _answerPrefub;

        private int _currentStoryNumber;
        private Dialog _currentDialog;

        public void FinishDialog()
        {
            InputHandler.Input.WorldMovement.Enable();
            InputHandler.Input.Dialog.Disable();
            _currentDialog = null;
            _dialogWindow.SetActive(false);
        }

        private void NextStory()
        {
            _currentStoryNumber++;
            InputHandler.Input.Dialog.Enable();
            if (_currentStoryNumber >= _currentDialog.Story.Length)
            {
                if (_currentDialog.Answers.Length == 0)
                {
                    FinishDialog();
                    return;
                }
                InputHandler.Input.Dialog.Disable();
                ShowAnswers(_currentDialog.Answers);
                return;
            }
            _dialogTextPlace.text = _currentDialog.Story[_currentStoryNumber];
        }

        public void StartDialog(Dialog dialog)
        {
            _currentDialog = dialog;
            _currentStoryNumber = -1;
            foreach (Transform answer in _answerContainer)
            {
                Destroy(answer.gameObject);
            }
            _dialogWindow.SetActive(true);
            NextStory();
        }

        private void Awake()
        {
            InputHandler.Input.Dialog.NextStory.started += (InputAction.CallbackContext context) => { NextStory(); };
        }

        private void ShowAnswers(Answer[] answers)
        {
            _dialogTextPlace.text = "";
            int currentAnswerNumber = 0;
            foreach (Answer answer in answers)
            {
                int copyCurrentAnswerNumber = currentAnswerNumber;
                Instantiate(_answerPrefub, _answerContainer).Init(answer.Text, () =>
                {
                    StartDialog(_currentDialog.Answers[copyCurrentAnswerNumber].NextDialog);
                });
                currentAnswerNumber++;
            }
        }
    }

}