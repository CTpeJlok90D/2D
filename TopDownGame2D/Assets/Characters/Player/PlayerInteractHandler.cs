using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInteractHandler : InteractHandler
    {
        private Input.PlayerInput _input;
        private void Awake()
        {
            _input = new Input.PlayerInput();
            _input.WorldMovement.Interact.started += Interact;
        }

        private void OnEnable()
        {
            _input.WorldMovement.Enable();
        }

        private void OnDisable()
        {
            _input.WorldMovement.Disable();
        }

        private void Interact(InputAction.CallbackContext context)
        {
            Interact();
        }
    }
}
