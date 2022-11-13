using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Dialog
{
    public class Dialoger : MonoBehaviour
    {
        [SerializeField] private Transform _dialogWindow;
        [SerializeField] private Image _characterImage;
        [SerializeField] private TMP_Text _dialogTextPlace;
        [SerializeField] private Transform _answerContainer;
        [SerializeField] private AnswerView _answerPrefub;

        private int _currentStoryNumber;
        private Dialog _currentDialog;

        private void Awake()
        {
            InputHandler.Input.Dialog.NextStory.started += (InputAction.CallbackContext context) => { NextStory(); };
        }

        public void FinishDialog()
        {
            InputHandler.Input.WorldMovement.Enable();
            InputHandler.Input.Dialog.Disable();
            _currentDialog = null;
            _characterImage.sprite = null;
            _dialogWindow.gameObject.SetActive(false);
        }

        private void NextStory()
        {
            _currentStoryNumber++;
            InputHandler.Input.Dialog.Enable();
            if (_currentStoryNumber >= _currentDialog.Storys.Length)
            {
                _currentDialog.StoryEnded.Invoke();
                if (_currentDialog.Answers.Length == 0)
                {
                    FinishDialog();
                    return;
                }
                InputHandler.Input.Dialog.Disable();
                ShowAnswers(_currentDialog.Answers);
                return;
            }
            _dialogTextPlace.text = _currentDialog.Storys[_currentStoryNumber].Text;
            if (_currentDialog.Storys[_currentStoryNumber].IntercolutorSprite != null)
            {
                _characterImage.sprite = _currentDialog.Storys[_currentStoryNumber].IntercolutorSprite;
            }
        }

        public void StartDialog(Dialog dialog)
        {
            _currentDialog = dialog;
            _currentStoryNumber = -1;
            foreach (Transform answer in _answerContainer)
            {
                Destroy(answer.gameObject);
            }
            _dialogWindow.gameObject.SetActive(true);
            NextStory();
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