using System.Collections.Generic;
using UnityEngine;
using AI.Tasks;
using System.Collections;
using Unity.VisualScripting;

namespace AI
{
    public class AI : MonoBehaviour
    {
        [SerializeField] private Transform _moveTarget;
        [SerializeField] private List<Task> _tasks;

        private Task _preferentTask;

        private void UpdatePreferentTask()
        {
            _preferentTask = _tasks[0];
            foreach (Task task in _tasks)
            {
                if (task.Priority > _preferentTask.Priority)
                {
                    _preferentTask = task;
                }
            }
        }

        private void Update()
        {
            UpdatePreferentTask();
            _preferentTask.Execute();
        }
    }
}
