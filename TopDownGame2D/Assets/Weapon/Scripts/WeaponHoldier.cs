using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons 
{
    public class WeaponHoldier : MonoBehaviour
    {
        [SerializeField] private Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;
        public bool CanShoot => _currentWeapon != null;

        public void Attack(InputAction.CallbackContext context)
        {
            if (CanShoot)
            {
                _currentWeapon.Use(context.phase);
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
