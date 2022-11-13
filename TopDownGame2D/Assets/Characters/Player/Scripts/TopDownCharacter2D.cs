using UnityEngine;

namespace Character
{
    public abstract class TopDownCharacter2D : MonoBehaviour
    {
        [SerializeField] private float _maxMoveSpeed;
        [SerializeField] private float _speedBoost;
        [SerializeField] private Rigidbody2D _rigidBody;

        private Vector2 _moveDirection;

        private float currentSpeed => Mathf.Sqrt(Mathf.Pow(_rigidBody.velocity.x, 2) + Mathf.Pow(_rigidBody.velocity.y, 2));

        public bool IsMoving => _moveDirection != Vector2.zero;
        public Vector2 MoveDirection => _moveDirection;

        protected void Move(Vector2 direction)
        {
            _moveDirection = direction.normalized;
            if (currentSpeed < _maxMoveSpeed)
            {
                float boost = Mathf.Clamp(_speedBoost * Time.deltaTime, -_maxMoveSpeed, _maxMoveSpeed);
                _rigidBody.velocity += boost * _moveDirection;
            }
        }
    }
}