using UnityEngine;
using AI.Tasks;
using System;

namespace AI.Memory
{
    [Serializable]
    public class Memory
    {
        [SerializeField] float _coefficient;
        [SerializeField] private Task _task;
        [SerializeField] private float _dituration;

        public Memory(float dituration, Task task)
        {
            _dituration = dituration;
            _task = task;
        }

        public float Dituration => _dituration;

        public Memory Copy()
        {
            return new Memory(_dituration, _task);
        }
        public void Update()
        {
            _dituration = Mathf.Clamp(_dituration - Time.deltaTime, 0, Mathf.Infinity);
        }
    }   
}