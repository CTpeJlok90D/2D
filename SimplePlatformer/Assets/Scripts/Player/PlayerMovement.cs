using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : CharacterController2D
    {
        public void Move(InputAction.CallbackContext context)
        {
            Move(context.ReadValue<float>());
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                StopJump();
                return;
            }
            if (context.performed) 
            {
                return; 
            }
            Jump();
        }

        public void Crouch(InputAction.CallbackContext context)
        {
            if (context.started || context.performed)
            {
                StartCrouch();
                return;
            }
            StopCrouch();
        }
    }
}
