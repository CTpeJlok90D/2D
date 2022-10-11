using UnityEngine;

namespace AI.Tasks
{
    public class Attack : Task
    {
        [SerializeField] private Abilitys.Attack _attackAbility;
        [SerializeField] private Mover _mover;
        [SerializeField] private Transform _target;
        [SerializeField] private KeepDistance _keepDistance;

        public override void Execute()
        {
            _keepDistance.SetTarget(_target);
            _keepDistance.Execute();
            if (_mover.OnPoint)
            {
                _attackAbility.Use();
            }
        }
    }
}
