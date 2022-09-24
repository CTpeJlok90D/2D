using UnityEngine;

namespace Effects
{
    public class Dash : Effect
    {
        private float _dashVelocity;
        private AnimationCurve _speedCurve;
        private float _direction = 1f;
        public override bool Visible => false;
        public Dash(AnimationCurve speedCurve, float direction) : base(speedCurve.keys[speedCurve.length - 1].time)
        {
            _speedCurve = speedCurve;
            _direction = direction;
        }

        public override Impact GetImpact()
        {
            return new Impact()
            {
                Kick = new Vector2(_speedCurve.Evaluate(Diruration) * _direction, 0)
            };
        }
    }
}