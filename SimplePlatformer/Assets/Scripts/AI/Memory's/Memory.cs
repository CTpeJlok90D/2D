using UnityEngine;
using AI.Tasks;
using System;
using System.Collections.Generic;

namespace AI.Memory
{
    [Serializable]
    public class Memory
    {
        [SerializeField] int _priorityChange;
        [SerializeField] private Task _task;
        [SerializeField] private float _dituration;

        public Memory(float dituration, Task task)
        {
            _dituration = dituration;
            _task = task;
        }

        private Memory(float dituration, Task task, int priorityChange)
        {
            _priorityChange = priorityChange;
            _task = task;
            _dituration = dituration;
        }

        public float Dituration => _dituration;

        public Memory Copy()
        {
            return new Memory(_dituration, _task, _priorityChange);
        }

        public void UpdateDituration(float dituration)
        {
            _dituration = dituration;
        }

        public void ReduceCooldown(float time)
        {
            _dituration = Mathf.Clamp(_dituration - time, 0, Mathf.Infinity);
        }

        public void ImpactOnPriority()
        {
            _task.Priority += _priorityChange;
        }

        public void RemoveImpactOnPriority() 
        {
            _task.Priority -= _priorityChange;
        }

        public override bool Equals(object obj)
        {
            return obj is Memory memory &&
                   EqualityComparer<Task>.Default.Equals(_task, memory._task);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_task);
        }

        public static bool operator ==(Memory a, Memory b)
        {
            return a._task == b._task;
        }
        public static bool operator !=(Memory a, Memory b)
        {
            return a._task != b._task;
        }
    }   
}