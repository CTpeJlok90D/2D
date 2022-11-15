using UnityEngine;

namespace Abilitys
{
    public class Dash : Ability
    {
        [SerializeField] private float _dashStrench;
        [SerializeField] private Rigidbody2D _owner;
        [SerializeField] private Transform _head;

        protected override void Execute()
        {
            _owner.AddForce(_head.up * _dashStrench);
        }

        private void Awake()
        {
            InputHandler.Singletone.WorldMovement.Dash.started += Use;
        }
    }
}