using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Tasks
{
    public abstract class Task : MonoBehaviour
    {
        public abstract int Priority { get; }

        public abstract void Execute();
    }
}