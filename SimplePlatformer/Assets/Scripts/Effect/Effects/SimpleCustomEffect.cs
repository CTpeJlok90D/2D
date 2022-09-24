using System;
using UnityEngine;

namespace Effects
{

    public class SimpleEffect : Effect
    {
        private Impact _impact;
        public SimpleEffect(float dituratuin, Impact impact) : base(dituratuin) 
        {
            _impact = impact;
        }

        public override Impact GetImpact()
        {
            return _impact;
        }
    }
}