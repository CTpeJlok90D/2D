using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private AnimationCurve _jumpCurve;
        [SerializeField] private float _jumpCooldown;
        [SerializeField] private Vector2 _groundRayCastOffcet;

        private float _moveDirection = 0f;
        private float _jumpForse = 0f;
        private Rigidbody2D _rigidbody2D;
        private float _cantJumpNextTime = 0f;
        private Coroutine _jumpCoroutine;
        private bool _jumping;

        public bool Walking => _moveDirection != 0;
        public bool CanJump => _cantJumpNextTime == 0;
        public bool OnGround => _rigidbody2D.velocity.y == 0 && Physics2D.Raycast((Vector2)transform.position + _groundRayCastOffcet, Vector2.down, 0.1f);
        public bool Jumping => _jumping;
        public float MoveDirection => _moveDirection;

        protected void Move(float direction)
        {
            _moveDirection = direction;
        }

        protected void Jump()
        {
            if (CanJump == false)
            {
                return;
            }
            _jumpCoroutine = StartCoroutine(nameof(JumpCorrutine));
        }

        protected void StopJump()
        {
            StopCoroutine(_jumpCoroutine);
            _jumping = false;
            _jumpForse = 0;
        }

        private IEnumerator JumpCorrutine()
        {
            _jumping = true;
            for (float i = 0; i < _jumpCurve.keys[_jumpCurve.keys.Length - 1].time; i += Time.fixedDeltaTime)
            {
                _jumpForse = _jumpCurve.Evaluate(i);
                _cantJumpNextTime = _jumpCooldown;
                _rigidbody2D.velocity += new Vector2(0, _jumpForse);
               yield return null;
            }
            _jumping = false;
            _jumpForse = 0;
        }

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.velocity = new Vector2(_speed * _moveDirection, _rigidbody2D.velocity.y);
            if (OnGround && _cantJumpNextTime > 0)
            {
                _cantJumpNextTime = Mathf.Clamp(_cantJumpNextTime - Time.fixedDeltaTime, 0, Mathf.Infinity);
            }
        }
    }
}