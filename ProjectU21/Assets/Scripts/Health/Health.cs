using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Health
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private LimitedValue _current = new(100f, 100f, 0);
        [SerializeField] private LimitedValue _damageMultiplier = new(1f, 2f, 0.05f);
        [SerializeField] private UnityEvent _death;
        [SerializeField] private UnityEvent _healtUpdated;

        public float Current => _current.Current;

        public void Heal(float value)
        {
            _current += value;
            _healtUpdated.Invoke();
        }

        public void Damage(float value)
        {
            _current -= value * _damageMultiplier;
            if (_current == 0)
            {
                _death.Invoke();
            }
            _healtUpdated.Invoke();
        }

        public void ApplyDamageMultiplier(float value)
        {
            _damageMultiplier += value;
        }
    }
}
