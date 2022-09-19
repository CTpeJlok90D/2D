using UnityEngine;
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
            Jump();
        }
    }
}
