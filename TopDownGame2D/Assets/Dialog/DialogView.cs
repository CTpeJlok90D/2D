using TMPro;
using UnityEngine;

namespace Dialog
{
    public class DialogView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _dialogTextPlace;

        private int _currentStoryNumber;
        private Dialog _currentDialog;

        public void OnDialogChange(Dialog dialog)
        {
            _currentDialog = dialog;
            _currentStoryNumber = 0;
            NextStory();
        }

        public void NextStory()
        {
            _dialogTextPlace.text = _currentDialog.Story[_currentStoryNumber];
            _currentStoryNumber++;
        }
    }

}