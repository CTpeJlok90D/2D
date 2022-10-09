using System;
using UnityEngine;

namespace AI.Memory
{
    [Serializable]
    public class MemoryDictionarity
    {
        [SerializeField] private Factor _factor;
        [SerializeField] private Memory _reaction;

        public Factor Factor => _factor;
        public Memory Memory => _reaction;
    }
}
