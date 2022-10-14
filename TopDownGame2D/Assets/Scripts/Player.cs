using UnityEngine;
using UnityEngine.InputSystem;

public class Player : TopDownCharacter2D
{
    private Vector2 _currentDirection;
    public void Move(InputAction.CallbackContext context)
    {
        _currentDirection = context.ReadValue<Vector2>();
    }

    public void LookAtMouse(InputAction.CallbackContext context)
    {
        Vector2 mouseScreenPosition = context.ReadValue<Vector2>();
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        transform.up = (Vector2)transform.position - mousePosition;
    }

    private void Update() 
    {
        Move(_currentDirection);    
    }
}