using Dialog;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Dialoger _dialoger;
    [SerializeField] private UnityEvent _gamePaused;
    [SerializeField] private UnityEvent _gameContinue;
    private bool _isPaused;

    private void Start()
    {
        InputHandler.Singletone.PauseMenu.Enable();
        InputHandler.Singletone.PauseMenu.OpenClose.Enable();
        InputHandler.Singletone.PauseMenu.OpenClose.started += (InputAction.CallbackContext context) => OnMenuOpen();
    }

    public void OnMenuOpen()
    {
        _isPaused = _isPaused == false;
        _pauseMenu.SetActive(_isPaused);
        if (_isPaused)
        {
            GanePause();
            return;
        }
        GameContinue();
    }

    private void GanePause()
    {
        Time.timeScale = 0;
        InputHandler.Singletone.WorldMovement.Disable();
        InputHandler.Singletone.Dialog.Disable();
        _gamePaused.Invoke();
    }

    private void GameContinue()
    {
        InputHandler.Singletone.WorldMovement.Enable();
        if (_dialoger.InDialog)
        {
            InputHandler.Singletone.WorldMovement.Disable();
            InputHandler.Singletone.Dialog.Enable();
        }
        Time.timeScale = 1;
        _gameContinue.Invoke();
    }
}
