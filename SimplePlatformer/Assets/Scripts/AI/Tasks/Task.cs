using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Tasks
{
    public abstract class Task : MonoBehaviour
    {
        public int Priority;

        public abstract void Execute();        
    }
}