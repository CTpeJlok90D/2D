using UnityEngine;
using UnityEngine.Events;
using Weapons;

namespace Player
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onDrop = new UnityEvent();
        [SerializeField] private UnityEvent _onPickUp = new UnityEvent();

        private bool _onFloor = true;
        private GameObject _owner;

        public bool OnFloor => _onFloor;
        public UnityEvent OnDrop => _onDrop;
        public UnityEvent OnPickUp => _onPickUp;

        public void Drop()
        {
            _onFloor = true;
            transform.SetParent(null);
            _onDrop.Invoke();
        }

        public void PickUp(GameObject owner)
        {
            _owner = owner;
            transform.SetParent(_owner.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            _onFloor = false;
            _onPickUp.Invoke();
        }
    }
}
