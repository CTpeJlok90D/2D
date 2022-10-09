using UnityEngine;

namespace AI.Memory
{
    public class AIreaction : MonoBehaviour
    {
        [SerializeField] private Factor _factorType;

        public Factor Factor => _factorType;
    }
}
