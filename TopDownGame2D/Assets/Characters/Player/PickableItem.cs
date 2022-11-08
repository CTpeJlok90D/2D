using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public abstract class PickableItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onDrop = new UnityEvent();
        [SerializeField] private UnityEvent<Transform> _onPickUp = new UnityEvent<Transform>();

        private bool _onFloor = true;

        public bool OnFloor => _onFloor;
        public UnityEvent OnDrop => _onDrop;
        public UnityEvent<Transform> OnPickUp => _onPickUp;

        public void Drop()
        {
            _onFloor = true;

            _onDrop.Invoke();
        }

        public void Take(Transform ownerWeaponHandler)
        {
            _onFloor = false;

            _onPickUp.Invoke(ownerWeaponHandler);
        }
    }
}
