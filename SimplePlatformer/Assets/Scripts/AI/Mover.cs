using UnityEngine;
using UnityEngine.Events;

namespace AI
{
    public class Mover : CharacterController2D
    {
        [Header("AI Mover settings")]
        [SerializeField] private float _minDistanceToTarget;
        [SerializeField] private UnityEvent _onPointArrival = new();

        private bool _onPoint = false;

        public UnityEvent OnPointArriaval => _onPointArrival;
        public bool OnPoint => _onPoint;
        public float MinDistanceToTarget => _minDistanceToTarget;

        public void Move(Vector2 target)
        {
            if (Mathf.Abs(target.x - transform.position.x) > _minDistanceToTarget) 
            {
                float side = Mathf.Sign(target.x - transform.position.x);
                Move(side);
            }
            else
            {
                OnPointArriaval.Invoke();
                Move(0);
            }
        }
    }
}
