using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class AIKnok : MonoBehaviour
    {
        [SerializeField] private List<AIKnok> _neighbors;

        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 0.5f);
            if (_neighbors.Count != 0)
            {
                foreach (AIKnok variable in _neighbors)
                {
                    Gizmos.DrawLine(transform.position, variable.transform.position);
                }
            }
        }
    }
}