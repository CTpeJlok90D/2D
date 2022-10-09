using System.Collections.Generic;
using UnityEngine;

namespace AI.Memory
{
    public class Brain : MonoBehaviour
    {
        [SerializeField] private List<Memory> _memorys = new();

        public void AddMemory(Memory memory)
        {
            _memorys.Add(memory);
        }
    }
}