using UnityEngine;

namespace Health
{
    class DamageImpact : MonoBehaviour
    {
        [SerializeField] private GameObject _hitSummonObject;

        public GameObject HitSummonObject => _hitSummonObject;
    }
}
