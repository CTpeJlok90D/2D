using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons 
{
    public class WeaponHoldier : MonoBehaviour
    {
        [SerializeField] private Weapon _currentWeapon;
        private Input.PlayerInput _input;

        public Weapon CurrentWeapon => _currentWeapon;
        public bool CanShoot => _currentWeapon != null;

        private void Awake()
        {
            _input = new Input.PlayerInput();
            _input.WorldMovement.Shoot.started += Attack;
        }

        private void OnEnable()
        {
            _input.WorldMovement.Enable();
        }

        private void OnDisable()
        {
            _input.WorldMovement.Disable();
        }

        public void Attack(InputAction.CallbackContext context)
        {
            if (CanShoot)
            {
                _currentWeapon.Use(context.phase);
            }
        }

        public void DropWeapon()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.Drop();
                _currentWeapon = null;
            }
        }

        public void PutWeapon(Weapon weapon) 
        {
            DropWeapon();
            weapon.PickUp(transform);
            _currentWeapon = weapon;
        }
    }
}
