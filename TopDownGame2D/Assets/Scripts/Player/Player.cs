using UnityEngine;
using UnityEngine.InputSystem;
using Character;
using TMPro;

namespace Player
{ 
    public class Player : TopDownCharacter2D
    {
        private Vector2 _currentDirection;

        public void Move(InputAction.CallbackContext context)
        {
            _currentDirection = context.ReadValue<Vector2>();
        }

        public void LookAtMouse()
        {
            LookAt(WorldMouse.Position);
        }

        private void Update() 
        {
            Move(_currentDirection);
            LookAtMouse();
        }
    }
}