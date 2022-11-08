using UnityEngine;
using UnityEngine.Events;
using Player;
using System.Collections;
using UnityEngine.InputSystem;

namespace Weapons 
{
    public abstract class Weapon : PickableItem
    {
        [SerializeField] private UnityEvent _onShoot = new UnityEvent();
        [SerializeField] private float _timeBetweenShoots = 0.1f;
        [SerializeField] private int _ammoCount = 30;
        
        private float _cantShootNextSeconds = 0;

        public bool CanShoot => _cantShootNextSeconds == 0 && _ammoCount > 0;

        protected abstract void ForsetShoot();
        public abstract void Use(InputActionPhase phase);

        protected void Shoot()
        {
            if (CanShoot == false)
            {
                return;
            }

            _cantShootNextSeconds += _timeBetweenShoots;
            _ammoCount -= 1;
            ForsetShoot();
            _onShoot.Invoke();
        }

        protected virtual void Update()
        {
            ReduceCoolDown(Time.deltaTime);
        }

        protected void ReduceCoolDown(float value)
        {
            _cantShootNextSeconds = Mathf.Clamp(_cantShootNextSeconds - value, 0, Mathf.Infinity);
        }

        private new void OnPickUp(Transform owner)
        {
            transform.SetParent(owner);
            transform.localPosition = new Vector3(0, 0, transform.position.z);
            transform.localRotation = Quaternion.identity;
        }

        private new void OnDrop()
        {
            transform.SetParent(null);
            transform.localRotation = Quaternion.identity;
        }

        private void OnEnable()
        {
            base.OnPickUp.AddListener(OnPickUp);
            base.OnDrop.AddListener(OnDrop);
        }

        private void OnDisable()
        {
            base.OnPickUp.RemoveListener(OnPickUp);
            base.OnDrop.RemoveListener(OnDrop);
        }
    }
}