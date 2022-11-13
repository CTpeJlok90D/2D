using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCamera
{
    public class CameraMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _speedBoost = 2f;
        [Header("Rotation")]
        [SerializeField] private float _rotateSpeed = 2f;
        private CameraMovementInput _cameraInput;
        private bool _isBoosted;

        private void Awake()
        {
            _cameraInput = new CameraMovementInput();
            EventSubscribe();
        }

        private void EventSubscribe()
        {
            _cameraInput.InputMapSwitch.ChangeMoveActionMap.started += ChangeMoveActionMap;
            _cameraInput.InputMapSwitch.ChangeMoveActionMap.canceled += ChangeMoveActionMap;

            _cameraInput.InputMapSwitch.ChangeRotateActionMap.started += ChangeRotateActionMap;
            _cameraInput.InputMapSwitch.ChangeRotateActionMap.canceled += ChangeRotateActionMap;

            _cameraInput.KeyboardMove.Boost.started += (InputAction.CallbackContext context) => { _isBoosted = true; };
            _cameraInput.KeyboardMove.Boost.canceled += (InputAction.CallbackContext context) => { _isBoosted = false; };

            _cameraInput.MouseRotate.Rotate.performed += Rotate;
            _cameraInput.MouseMove.Delta.performed += Move;
        }

        private void ChangeMoveActionMap(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _cameraInput.KeyboardMove.Disable();
                _cameraInput.MouseMove.Enable();
            }
            if (context.canceled)
            {
                _cameraInput.KeyboardMove.Enable();
                _cameraInput.MouseMove.Disable();
            }
        }

        private void ChangeRotateActionMap(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _cameraInput.KeyboardRotate.Disable();
                _cameraInput.MouseRotate.Enable();
            }
            if (context.canceled)
            {
                _cameraInput.KeyboardRotate.Enable();
                _cameraInput.MouseRotate.Disable();
            }
        }

        private void OnEnable()
        {
            _cameraInput.KeyboardMove.Enable();
            _cameraInput.KeyboardRotate.Enable();
            _cameraInput.InputMapSwitch.Enable();
        }

        private void OnDisable()
        {
            _cameraInput.Disable();
        }

        private void Update()
        {
            Vector2 moveDirection = _cameraInput.KeyboardMove.Move.ReadValue<Vector2>();
            Move(moveDirection);
            float rotateDirection = _cameraInput.KeyboardRotate.Rotate.ReadValue<float>();
            Rotate(rotateDirection);
        }

        private void Move(InputAction.CallbackContext context)
        {
            Vector3 direction = context.ReadValue<Vector2>();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            Vector3 offset = new Vector3(direction.x, 0, direction.y) * _speed * Time.deltaTime;
            if (_isBoosted)
            {
                offset *= _speedBoost;
            }
            transform.position += transform.TransformDirection(offset);
        }

        private void Rotate(InputAction.CallbackContext context)
        {
            float angle = context.ReadValue<float>();
            Rotate(angle);
        }

        private void Rotate(float direction)
        {
            transform.Rotate(0, direction * _rotateSpeed, 0);
        }
    }
}