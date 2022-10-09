using System.Collections.Generic;
using UnityEngine;
using AI.Tasks;
using System.Collections;

namespace AI
{
    public class AI : MonoBehaviour
    {
        [SerializeField] private Transform _moveTarget;
        [SerializeField] private List<Task> _tasks;

        private void Update()
        {
            _tasks[0].Execute();
        }
    }
}
