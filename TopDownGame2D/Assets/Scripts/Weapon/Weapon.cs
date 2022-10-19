using UnityEngine;
using Player;
using UnityEngine.Events;

namespace Weapons 
{
    public abstract class Weapon : PickableItem
    {
        [SerializeField] private UnityEvent _floorStateChanged = new();
        [SerializeField] private UnityEvent _onUse = new();
        [SerializeField] private UnityEvent _onPickUp = new();
        private bool _onFloor = true;

        public bool OnFloor => _onFloor;

        public void Shoot()
        {
            Use();
            _onUse.Invoke();
        }

        protected abstract void Use();

        public void Drop()
        {
            transform.SetParent(null);
            _onFloor = true;
            transform.localRotation = Quaternion.identity;

            _floorStateChanged.Invoke();
        }

        public void Take(Transform ownerWeaponHandler)
        {
            transform.SetParent(ownerWeaponHandler);
            _onFloor = false;
            transform.localPosition = new Vector3(0,0,transform.position.z);
            transform.localRotation = Quaternion.identity;

            _floorStateChanged.Invoke();
            _onPickUp.Invoke();
        }
    }
}