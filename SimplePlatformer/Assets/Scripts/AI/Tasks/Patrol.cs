using System.Collections.Generic;
using UnityEngine;

namespace AI.tasks
{
    public class Patrol : Task
    {
        [SerializeField] private Mover _mover;
        [SerializeField] private List<Vector2> _points;
        [SerializeField] private float _timeBetweenPoints = 1f;
        private int _currentPointIndex = 0;
        private Vector2 _currentPoint;
        private float _currentTimeOnPoint = 0;
        public override int Priority => 1;

        public override void Execute()
        {
            if (_currentTimeOnPoint == 0)
            {
                _mover.Move(_currentPoint);
            }
        }

        private void OnPoint()
        {
            _currentTimeOnPoint = _timeBetweenPoints;
            _currentPointIndex++;
            if (_currentPointIndex >= _points.Count) 
            {
                _currentPointIndex = 0;
            }
            _currentPoint = _points[_currentPointIndex];
        }

        private void Awake()
        {
            _currentPoint = _points[0];
            _mover.OnPointArriaval.AddListener(OnPoint);
        }

        private void Update()
        {
            _currentTimeOnPoint = Mathf.Clamp(_currentTimeOnPoint - Time.deltaTime, 0, Mathf.Infinity);
        }
    }
}
