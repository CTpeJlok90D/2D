using UnityEngine;

namespace Character
{
    public class LegsAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private TopDownCharacter2D _character;


        private void Update()
        {
            _animator.SetBool("IsMoving", _character.IsMoving);
        }
    }
}
