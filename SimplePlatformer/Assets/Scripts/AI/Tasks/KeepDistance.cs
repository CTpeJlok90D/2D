using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Tasks
{
    public class KeepDistance : Task
    {
        [SerializeField] private Transform _owner;
        [SerializeField] private Mover _mover;
        [SerializeField] private float _distance;
        [SerializeField] private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        public override void Execute()
        {
            _mover.Move(_target.position);
        }
    }
}
