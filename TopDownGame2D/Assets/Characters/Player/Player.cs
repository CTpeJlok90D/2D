using UnityEngine;
using UnityEngine.InputSystem;
using Character;

namespace Player
{ 
    public class Player : TopDownCharacter2D
    {
        private Vector2 _currentDirection;

        public void Move(InputAction.CallbackContext context)
        {
            _currentDirection = context.ReadValue<Vector2>();
        }

        private void Update() 
        {
            Move(_currentDirection);
        }
    }
}