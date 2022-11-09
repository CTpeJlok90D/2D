using UnityEngine;
using Weapons;

namespace Player 
{
    public class InteractHandler : MonoBehaviour
    {
        [SerializeField] private WeaponHoldier _weaponHolder;

        private IInteracteble _lastInteractebleInZone;
        
        public void Interact()
        {
            _lastInteractebleInZone.Interact(_weaponHolder.transform);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IInteracteble item))
            {
                _lastInteractebleInZone = item;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (_lastInteractebleInZone != null) 
            {
                _lastInteractebleInZone = null;
            }
        }
    }
}