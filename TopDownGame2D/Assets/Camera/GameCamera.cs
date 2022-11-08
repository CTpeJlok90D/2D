using UnityEngine;

namespace GameCamera
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _maxOffcetRadius;

        private Vector2 _targetOffset => _target.position - transform.position;

        public void Update()
        {
            if (Vector2.Distance(transform.position, _target.position) > _maxOffcetRadius)
            {
                transform.position = new Vector3(
                    _target.position.x - _targetOffset.x,
                    _target.position.y - _targetOffset.y,
                    transform.position.z);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _maxOffcetRadius);
        }
    }
}