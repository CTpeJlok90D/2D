using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class Mover : CharacterController2D
    {
        [Header("AI Mover settings")]
        [SerializeField] private float _minDistanceToTarget;
        [SerializeField] private UnityEvent _onPoint;

        public UnityEvent OnPoint => _onPoint;


        public void Move(Vector2 target)
        {
            float side = Mathf.Sign(target.x - transform.position.x);
            if (Vector2.Distance(target, transform.position) > _minDistanceToTarget) 
            {
                Move(side);
            }
            else
            {
                OnPoint.Invoke();
                Move(0);
            }
        }
    }
}
