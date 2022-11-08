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
            _currentWeapon.Use(context.phase);
        }

        public void DropWeapon()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.Drop();
                _currentWeapon = null;
            }
        }

        public void TakeWeapon(Weapon weapon) 
        {
            DropWeapon();
            weapon.Take(transform);
            _currentWeapon = weapon;
        }
    }
}
