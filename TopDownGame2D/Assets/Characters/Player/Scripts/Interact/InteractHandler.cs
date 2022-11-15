using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
using Dialog;

namespace Player 
{
    public class InteractHandler : MonoBehaviour
    {
        [SerializeField] private WeaponHoldier _weaponHolder;
        [SerializeField] private Dialoger _dialogView;
        [SerializeField] private Player _player;

        private IInteracteble _lastInteractebleInZone;

        private void Awake()
        {
            InputHandler.Singletone.WorldMovement.Interact.started += Interact;
        }

        public void Interact(InputAction.CallbackContext context)
        {
            _lastInteractebleInZone?.Interact(new InteractInfo()
            {
                WeaponHoldier = _weaponHolder,
                DialogView = _dialogView
            });
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