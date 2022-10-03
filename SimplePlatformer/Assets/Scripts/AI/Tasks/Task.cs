using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.tasks
{
    public abstract class Task : MonoBehaviour
    {
        public abstract int Priority { get; }

        public abstract void Execute();
    }
}