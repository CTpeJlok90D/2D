using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons 
{
    public class WeaponHoldier : MonoBehaviour
    {
        [SerializeField] private Weapon _currentWeapon;

        public Weapon CurrentWeapon => _currentWeapon;

        public void Attack(InputAction.CallbackContext context)
        {
            if (context.started) 
            {
                _currentWeapon.Use();
            }
        }

        public void DropWeapon()
        {
            if (_currentWeapon != null)
            {
                _currentWeapon.transform.SetParent(null);
            }
        }

        public void TakeWeapon(Weapon weapon) 
        {
            DropWeapon();
            weapon.transform.SetParent(transform);
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
            _currentWeapon = weapon;
        }
    }
}
