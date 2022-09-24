using UnityEngine;
namespace Effects
{
    internal class Kick : Effect
    {
        private Vector2 _kickDirection;

        public Kick(Vector2 punchDirecton) : base(0)
        {
            _kickDirection = punchDirecton;
        }

        public override Impact GetImpact()
        {
            return new()
            {
                Kick = FirstTick ? _kickDirection : Vector2.zero,
            };
        }
    }
}