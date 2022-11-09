using UnityEngine;
using UnityEngine.InputSystem;
using Character;
using Input;
using Unity.VisualScripting;

namespace Player
{ 
    public class Player : TopDownCharacter2D
    {
        private Vector2 _currentDirection;
        private Input.PlayerInput _input;

        private void Awake()
        {
            _input = new();
            _input.WorldMovement.Move.started += Move;
            _input.WorldMovement.Move.performed += Move;
            _input.WorldMovement.Move.canceled += Move;
        }

        private void OnEnable()
        {
            _input.WorldMovement.Enable();
        }

        private void OnDisable()
        {
            _input.WorldMovement.Disable();
        }

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