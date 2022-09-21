using UnityEngine;

namespace Health
{
    public class HealthAnimation : MonoBehaviour
    {
        [SerializeField] private EntityHealth _playerHealth;
        [SerializeField] private Animator _playerAnimator;

        private void Update() 
        {
            _playerAnimator.SetBool("Invulnerability", _playerHealth.Invulnerability);
        }     
    }
}
