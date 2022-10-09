using UnityEngine;
using AI.Tasks;

namespace AI.Memory
{
    public class Memory : MonoBehaviour
    {
        [SerializeField] private Task _task;
        protected float _dituration;

        public void Init(float dituration, Task task)
        {
            _dituration = dituration;
            _task = task;
        }

        public float Dituration => _dituration;

        public void ReduseDituration(float value)
        {
            _dituration = Mathf.Clamp(_dituration - value, 0, Mathf.Infinity);
        }
    }   
}