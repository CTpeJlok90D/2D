using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Memory
{
    [Serializable]
    public class MemoryDictionarity
    {
        [SerializeField] private Factor _factor;
        [SerializeField] private List<Memory> _reaction;

        public Factor Factor => _factor;
        public List<Memory> Memorys => _reaction;
    }
}
