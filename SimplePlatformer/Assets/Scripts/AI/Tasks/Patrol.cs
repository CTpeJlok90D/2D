using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Tasks
{
    [Serializable]
    public class Patrol : ITask
    {
        [SerializeField] private List<Vector2> _patrolPoints;
        [SerializeField] private Mover _mover;
        private int _currentPointIndex;
        private Vector2 _currentPoint;

        public Patrol(Mover mover)
        {
            _mover.OnPoint.AddListener(ChangePoint);
        }

        public int Priority => 1;

        public void Execute()
        {
            _mover.Move(_currentPoint);
        }

        private void ChangePoint()
        {
            _currentPointIndex++;
            if (_patrolPoints.Count >= _currentPointIndex)
            {
                _currentPointIndex = 0;
            }
            _currentPoint = _patrolPoints[_currentPointIndex];
        }
    }
}
