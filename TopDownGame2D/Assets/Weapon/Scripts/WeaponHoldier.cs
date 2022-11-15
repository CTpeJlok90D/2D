using UnityEngine;
using UnityEngine.InputSystem;
using Weapon;

namespace Weapons 
{
    public class WeaponHoldier : MonoBehaviour
    {
        [Header("Weapon holdier")]
        [SerializeField] private Weapon _currentWeapon;
        [SerializeField] private XPcontainer _owenerXPContainter;

        public Weapon CurrentWeapon => _currentWeapon;
        public bool CanShoot => _currentWeapon != null;

        public void Awake()
        {
            InputHandler.Singletone.WorldMovement.Shoot.started += Attack;
            InputHandler.Singletone.WorldMovement.Shoot.canceled += Attack;
            InputHandler.Singletone.WorldMovement.Shoot.performed += Attack;
            InputHandler.Singletone.WorldMovement.Reload.started += (InputAction.CallbackContext context) => Reload();
            InputHandler.Singletone.WorldMovement.DropWeapon.started += (InputAction.CallbackContext context) => DropWeapon();
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
            if (_currentWeapon != null)
            {
                _currentWeapon.OwnerXpContainer = null;
            }
            _currentWeapon = null;
        }

        public void PutWeapon(Weapon weapon) 
        {
            DropWeapon();
            _currentWeapon = weapon;
            _currentWeapon.OwnerXpContainer = _owenerXPContainter;
            weapon.PickUp(gameObject);
        }
    }
}
