using UnityEngine;
using Weapons;

namespace Player 
{
    public class InteractHandler : MonoBehaviour
    {
        [SerializeField] private WeaponHoldier _weaponHolder;

        [SerializeField] private PickableItem _lastItemInZone;

        public void Interact()
        {
            if (_lastItemInZone != null && _lastItemInZone.TryGetComponent(out Weapon weapon)) 
            {
                _weaponHolder.TakeWeapon(weapon);
                return;
            }
            if (_lastItemInZone == null) 
            {
                _lastItemInZone = _weaponHolder.CurrentWeapon;
                _weaponHolder.DropWeapon();
            }            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PickableItem pickableItem)) 
            {
                _lastItemInZone = pickableItem;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_lastItemInZone != null && other.gameObject == _lastItemInZone.gameObject) 
            {
                _lastItemInZone = null;
            }
        }
    }
}