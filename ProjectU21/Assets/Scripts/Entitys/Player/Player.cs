using UnityEngine;
using UnityEngine.InputSystem;

public class Player : CharacterController2D
{
    private bool _sptinting = false;

    public void Move(InputAction.CallbackContext context)
    {
        int input = (int)context.ReadValue<Vector2>().x;
        if (context.canceled == true)
        {
            Stop();
            return;
        }
        if (_sptinting)
        {
            Run(input);
            return;
        }
        Walk(input);
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        _sptinting = context.canceled == false;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (OnGround && context.started)
        {
            Jump();
        }
    }
}