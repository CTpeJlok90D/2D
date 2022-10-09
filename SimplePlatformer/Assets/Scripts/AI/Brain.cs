using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AI.Memory
{
    public class Brain : MonoBehaviour
    {
        [SerializeField] private List<Memory> _memorys = new();
        [SerializeField] private List<MemoryDictionarity> _reactions = new();

        private Dictionary<Factor, Memory> _reactionDictionarity = new();

        public void Awake()
        {
            foreach (MemoryDictionarity reaction in _reactions)
            {
                _reactionDictionarity.Add(reaction.Factor, reaction.Memory);
            }
        }

        public void AddFactor(Factor factor)
        {
            _memorys.Add(_reactionDictionarity[factor].Copy());
        }
    }
}