using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public sealed class AIMovement : CharacterController2D
    {
        [SerializeField] private float _targetXPosition;
        private List<AIKnok> _knoks = new();

        private void Update() 
        {
            Move();
        }

        private void Move()
        {
            float moveDirection = Mathf.Sign(_targetXPosition - transform.position.x);
            Move(moveDirection);
        }
    }
}