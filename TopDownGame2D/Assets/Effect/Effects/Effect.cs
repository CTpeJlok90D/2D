using System;
using UnityEngine;
using UnityEngine.Events;

namespace Effects
{
    public abstract class Effect
    {
        private float _dituration;
        private bool _firstTick = true;
        private UnityEvent _onDiturationEnd = new();
        public float Diruration => _dituration;
        public bool FirstTick => _firstTick;
        public UnityEvent OnDiturationEnd => _onDiturationEnd;
        public virtual bool Visible => false;
        public virtual bool Permanent => false;

        public Effect(float dituratuin)
        {
            _dituration = dituratuin;
        }

        public void RemoveDiruration(float value)
        {
            _dituration = Mathf.Clamp(_dituration - Time.deltaTime, 0, Mathf.Infinity);
            _firstTick = false;
            if (_dituration <= 0 && Permanent == false)
            {
                _onDiturationEnd.Invoke();
            }
        }

        public void Remove()
        {
            _dituration = 0;
        }

        public abstract Impact GetImpact();
    }
}