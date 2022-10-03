using UnityEngine;
using Abilitys;

public class AIAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterController2D _characterController2D;
    [SerializeField] private GroundCheker _groundCheker;
    [SerializeField] private Attack _attack;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void OnAttackCancel()
    {
        _animator.SetBool("AttackPrepairCanceled", true);
    }

    private void Update()
    {
        _animator.SetBool("Jumping", _characterController2D.Jumping);
        _animator.SetBool("Falling", _groundCheker.OnGround == false);
        _animator.SetBool("Walking", _characterController2D.Moving);
        _animator.SetBool("Crouching", _characterController2D.Crouching);
        _animator.SetBool("AttackPrepair", _attack.Prepearing);
        _animator.SetBool("AttackPrepairCanceled", false);
    }
}
