using UnityEngine;

namespace AI.tasks
{
    public class Attack : Task
    {
        [SerializeField] private Abilitys.Attack _attackAbility;
        [SerializeField] private Mover _mover;
        [SerializeField] private Transform _target;
        [SerializeField] private KeepDistance _keepDistance;

        public override int Priority => 1;

        private void Awake()
        {
            _mover.OnPointArriaval.AddListener(_attackAbility.Use);
        }

        public override void Execute()
        {
            _keepDistance.SetTarget(_target);
            _keepDistance.Execute();
        }
    }
}
