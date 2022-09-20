using UnityEngine;

namespace AI
{
    public class AIKnok : MonoBehaviour
    {
        [SerializeField] private AIKnok[] _neighbors;

        private void OnDrawGizmos() 
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, 0.5f);
            foreach (AIKnok variable in _neighbors)
            {
                Gizmos.DrawLine(transform.position, variable.transform.position);
            }
        }
    }
}