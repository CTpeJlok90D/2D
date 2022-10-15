using UnityEngine;

namespace Character
{
    public abstract class TopDownCharacter2D : MonoBehaviour
    {
        [SerializeField] private float _maxMoveSpeed;
        [SerializeField] private float _speedBoost;
        [SerializeField] private Rigidbody2D _rigidBody;

        private Vector2 _moveDirection;

        private float _currentSpeed => Mathf.Sqrt(Mathf.Pow(_rigidBody.velocity.x, 2) + Mathf.Pow(_rigidBody.velocity.y, 2));

        public Vector2 MoveDirection => _moveDirection;

        protected void Move(Vector2 direction)
        {
            _moveDirection = direction;
            if (Mathf.Abs(direction.x) + Mathf.Abs(direction.y) > 1)
            {
                direction = direction / 0.6f;
            }
            if (_currentSpeed < _maxMoveSpeed)
            {
                float boost = Mathf.Clamp(_speedBoost * Time.deltaTime, -_maxMoveSpeed, _maxMoveSpeed);
                _rigidBody.velocity += boost * direction;
            }
        }

        protected void LookAt(Vector2 position)
        {
            transform.up = position - (Vector2)transform.position;
        }

        public void LateUpdate()
        {
            Debug.Log(_currentSpeed);
        }
    }
}