using UnityEngine;

namespace GameCamera
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _maxOffcet;

        public void Update()
        {
            Vector2 currentTargetOffcet = _target.position - transform.position;
            if (currentTargetOffcet.x > _maxOffcet.x || currentTargetOffcet.x < -_maxOffcet.x)
            {
                float cameraOffcet = currentTargetOffcet.x - _maxOffcet.y * Mathf.Sign(currentTargetOffcet.x);
                transform.position = new Vector3(
                    transform.position.x + cameraOffcet, 
                    transform.position.y,
                    transform.position.z);
            }
            if (currentTargetOffcet.y > _maxOffcet.y || currentTargetOffcet.y < -_maxOffcet.y) 
            {
                float cameraOffcet = currentTargetOffcet.y - _maxOffcet.y * Mathf.Sign(currentTargetOffcet.y);
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y + cameraOffcet,
                    transform.position.z);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, _maxOffcet * 2);
        }
    }
}