using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons 
{
    public class AutomaticRifle : Weapon
    {
        [SerializeField] private Transform _bulletSpawnpoint;
        [SerializeField] private GameObject _bulletPrefub;
        [SerializeField] private bool _fullAutomatic;

        private InputActionPhase _currentPhase;

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
