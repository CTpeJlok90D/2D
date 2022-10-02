using System.Collections.Generic;
using UnityEngine;
using AI.Tasks;

namespace AI
{
    public class AI : MonoBehaviour
    {
        [SerializeField] private Transform _moveTarget;
        [SerializeField] private Mover _mover;
        [SerializeField] private Patrol _patrol;

        private List<ITask> _tasks = new();

        private void Update()
        {
            _patrol.Execute();
        }
    }
}
