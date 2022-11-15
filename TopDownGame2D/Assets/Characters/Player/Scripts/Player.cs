using UnityEngine;
using UnityEngine.InputSystem;
using Character;

namespace Player
{ 
    public class Player : TopDownCharacter2D
    {
        [SerializeField] private Transform _head;
        private Vector2 _currentDirection;

        public bool CanMove => InputHandler.Singletone.WorldMovement.enabled;

        private void Start()
        {
            InputHandler.Singletone.WorldMovement.Enable();
        }

        private void OnEnable()
        {
            InputHandler.Singletone.WorldMovement.Move.started += Move;
            InputHandler.Singletone.WorldMovement.Move.performed += Move;
            InputHandler.Singletone.WorldMovement.Move.canceled += Move;
        }

        private void OnDisable()
        {
            InputHandler.Singletone.WorldMovement.Move.started -= Move;
            InputHandler.Singletone.WorldMovement.Move.performed -= Move;
            InputHandler.Singletone.WorldMovement.Move.canceled -= Move;
        }

        private void UpdateHeadRotate()
        {
            if (CanMove)
            {
                _head.transform.up = WorldMouse.Position - (Vector2)transform.position;
            }
        }

        public void Move(InputAction.CallbackContext context)
        {
            _currentDirection = context.ReadValue<Vector2>();
        }

        private void Update() 
        {
            Move(_currentDirection);
            UpdateHeadRotate();
        }
    }
}