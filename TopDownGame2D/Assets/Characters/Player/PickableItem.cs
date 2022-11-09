using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public abstract class PickableItem : MonoBehaviour, IInteracteble
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
            transform.SetParent(null);
            _onDrop.Invoke();
        }

        public void Interact(Transform ownerTransform)
        {
            PickUp(ownerTransform);
        }

        public void PickUp(Transform ownerTransform)
        {
            _onFloor = false;
            transform.SetParent(ownerTransform);
            transform.localPosition = Vector3.zero;
            _onPickUp.Invoke(ownerTransform);
        }
    }
}
