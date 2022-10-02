using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Tasks
{
    public interface ITask
    {
        public int Priority { get; }
        public void Execute();
    }
}