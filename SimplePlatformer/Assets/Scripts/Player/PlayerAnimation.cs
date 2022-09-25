using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController2D _characterController2D;
        [SerializeField] private Dash _dash;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private void Update()
        {
            _animator.SetBool("Jumping", _characterController2D.Jumping);
            _animator.SetBool("Falling", _characterController2D.OnGround == false);
            _animator.SetBool("Dashing", _dash.Dashing);
            _animator.SetBool("Walking", _characterController2D.Moving);
            if (_characterController2D.Moving)
            {
                _spriteRenderer.flipX = _characterController2D.MoveDirection == -1;
            }
        }
    }
}
