using UnityEngine;
using UnityEngine.InputSystem;
using Weapon;

namespace Weapons 
{
    public class WeaponHoldier : MonoBehaviour
    {
        [SerializeField] private Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;
        public bool CanShoot => _currentWeapon != null;

        public void Awake()
        {
            InputHandler.Input.WorldMovement.Shoot.started += Attack;
            InputHandler.Input.WorldMovement.Shoot.canceled += Attack;
            InputHandler.Input.WorldMovement.Shoot.performed += Attack;
            InputHandler.Input.WorldMovement.Reload.started += (InputAction.CallbackContext context) => Reload();
            InputHandler.Input.WorldMovement.DropWeapon.started += (InputAction.CallbackContext context) => DropWeapon();
        }

        public void Attack(InputAction.CallbackContext context)
        {
            if (CanShoot)
            {
                _currentWeapon.Use(context.phase);
            }
        }

        public void Reload()
        {
            if (_currentWeapon is IReloadeble)
            {
                ((IReloadeble)_currentWeapon)?.Reload();
            }
        }

        public void DropWeapon()
        {
            _currentWeapon?.Drop();
            _currentWeapon = null;
        }

        public void PutWeapon(Weapon weapon) 
        {
            DropWeapon();
            _currentWeapon = weapon;
            weapon.PickUp(transform);
        }
    }
}
