using UnityEngine;
using UnityEngine.Events;
using Player;
using UnityEngine.InputSystem;
using Weapon;

namespace Weapons 
{
    public abstract class Weapon : PickableItem, IInteracteble
    {
        [Header("Shoot")]
        [SerializeField] private UnityEvent _onShoot = new UnityEvent();
        [SerializeField] private float _timeBetweenShoots = 0.1f;
        [SerializeField] protected int ammoCount = 30;

        private float _cantShootNextSeconds = 0;

        public bool CanShoot => _cantShootNextSeconds == 0 && ammoCount > 0;

        protected abstract void ForsetShoot();
        public abstract void Use(InputActionPhase phase);

        public void Interact(InteractInfo info)
        {
            info.WeaponHoldier.PutWeapon(this);
        }

        protected void Shoot()
        {
            if (CanShoot == false)
            {
                return;
            }

            _cantShootNextSeconds += _timeBetweenShoots;
            ammoCount -= 1;
            ForsetShoot();
            _onShoot.Invoke();
        }

        protected void AddCantShootTime(float time)
        {
            _cantShootNextSeconds += time;
        }

        protected virtual void Update()
        {
            ReduceCoolDown(Time.deltaTime);
        }

        protected void ReduceCoolDown(float value)
        {
            _cantShootNextSeconds = Mathf.Clamp(_cantShootNextSeconds - value, 0, Mathf.Infinity);
        }
    }
}