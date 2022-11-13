using UnityEngine;

namespace Abilitys
{
    public class Dash : Ability
    {
        [SerializeField] private float _dashStrench;
        [SerializeField] private Rigidbody2D _owner;
        protected override void Execute()
        {
            _owner.AddForce(_owner.transform.up * _dashStrench);
        }
    }
}