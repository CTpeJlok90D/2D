using System.Collections.Generic;
using UnityEngine;

namespace AI.Memory
{
    public class Brain : MonoBehaviour
    {
        [SerializeField] private List<Memory> _memorys = new();
        [SerializeField] private List<MemoryDictionarity> _reactions = new();

        private Dictionary<Factor, List<Memory>> _reactionDictionarity = new();

        public void Awake()
        {
            foreach (MemoryDictionarity reaction in _reactions)
            {
                _reactionDictionarity.Add(reaction.Factor, reaction.Memorys);
            }
        }

        public void AddFactor(Factor factor)
        {
            foreach (Memory memory in _reactionDictionarity[factor]) 
            {
                bool added = false;
                foreach (Memory memoryIterator in _memorys)
                {
                    if (memoryIterator == memory)
                    {
                        memoryIterator.UpdateDituration(memory.Dituration);
                        added = true;
                    }
                }
                if (added == false)
                {
                    _memorys.Add(memory.Copy());
                    memory.ImpactOnPriority();
                }
            }
        }

        private void Update()
        {
            ReduceDetiration(Time.deltaTime);
        }

        private bool HaveItMemory(Memory memory)
        {
            foreach (Memory memoryIterator in _memorys)
            {
                if (memoryIterator == memory)
                {
                    return true;
                }
            }
            return false;
        }

        private void ReduceDetiration(float time)
        {
            foreach (Memory memory in _memorys.ToArray())
            {
                memory.ReduceCooldown(time);
                if (memory.Dituration <= 0)
                {
                    memory.RemoveImpactOnPriority();
                    _memorys.Remove(memory);
                }
            }
        }
    }
}