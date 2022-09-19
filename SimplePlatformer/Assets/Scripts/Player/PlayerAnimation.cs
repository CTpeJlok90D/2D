using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator),typeof(CharacterController2D),typeof(SpriteRenderer))]
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;
        private CharacterController2D _characterController2D;
        private SpriteRenderer _spriteRenderer;

        public void Walk()
        {
            
        }

        public void IDE()
        {
            
        }
        private void Update()
        {
            _animator.SetBool("Jumping", _characterController2D.Jumping);
            _animator.SetBool("Falling", _characterController2D.OnGround == false);
            if (_characterController2D.Walking)
            {
                _animator.SetBool("Walking", true);
                _spriteRenderer.flipX = _characterController2D.MoveDirection == -1;
            }
            else
            {
                _animator.SetBool("Walking", false);
            }
        }
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController2D = GetComponent<CharacterController2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
