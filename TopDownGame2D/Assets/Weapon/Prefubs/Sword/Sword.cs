using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons
{
    public class Sword : Weapon
    {
        [SerializeField] private SwordAttackSplesh _attackSpleshPrefab;
        [SerializeField] private Transform _attackSplestSpawnpoint;

        private void Awake()
        {
            WeaponUsed.AddListener(OnUse);
        }

        private void OnUse(InputActionPhase phase)
        {
            if (phase == InputActionPhase.Started)
            {
                Attack();
            }
        }

        protected override void ForsetAttack()
        {
            SwordAttackSplesh.Summon(_attackSpleshPrefab, _attackSplestSpawnpoint);
        }
    }
}