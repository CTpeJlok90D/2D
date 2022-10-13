using UnityEngine;

namespace AI.Tasks
{
    public class Wait : Task
    {
        [SerializeField] private Mover _characterController;
        public override void Execute()
        {
            _characterController.StopMoving();
        }
    }
}