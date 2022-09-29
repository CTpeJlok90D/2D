using UnityEngine;
using UnityEngine.AI;

namespace AI 
{
    public class Pawn : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        private TakeItem _haul;

        private void Start()
        {
            _haul = new TakeItem(_agent);
            _haul.Execute();
        }
    }
}
