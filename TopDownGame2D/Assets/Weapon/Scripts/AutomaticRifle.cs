using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Weapon;

namespace Weapons 
{
    public class AutomaticRifle : Weapon, IReloadeble
    {
        [SerializeField] private Transform _bulletSpawnpoint;
        [SerializeField] private GameObject _bulletPrefub;
        [SerializeField] private bool _fullAutomatic = false;
        [SerializeField] private int _maxAmmoCount = 30;
        [SerializeField] private float _reloadingTime = 0.5f;
        [SerializeField] private TimeLineEvent[] _onReloadEvent;
        private TimeLine reloadTimeLine;

        private InputActionPhase _currentPhase;
        private bool IsReloading => _reloadingTime > 0;

        private void Awake()
        {
            reloadTimeLine = new TimeLine(_onReloadEvent);
        }

        public void Reload()
        {
            AddCantShootTime(_reloadingTime);
            ammoCount = _maxAmmoCount;
            StartCoroutine(reloadTimeLine.StartTimerCorutine());
        }

        public override void Use(InputActionPhase phase)
        {
            _currentPhase = phase;
            if (phase == InputActionPhase.Started)
            {
                Shoot();
            }
        }

        protected override void ForsetShoot()
        {
            Instantiate(_bulletPrefub, _bulletSpawnpoint.position, _bulletSpawnpoint.rotation);
        }

        protected override void Update()
        {
            base.Update();
            if (_currentPhase == InputActionPhase.Performed && _fullAutomatic)
            {
                Shoot();
            }
        }
    }
}
