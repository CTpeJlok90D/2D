using UnityEngine;
using UnityEngine.Events;

namespace Health
{
    public class EntityHealth : MonoBehaviour
    {
        [SerializeField] private int _max = 3;
        [SerializeField] private int _current = 3;
        [SerializeField] private float _invulnerabilityAfterDamage = 1f;
        [SerializeField] private bool _invulnerability = false;
        [SerializeField] private UnityEvent _death;
        [SerializeField] private UnityEvent _takeDamage;
        [SerializeField] private UnityEvent _gotHeal;
        [SerializeField] private UnityEvent _currentChanged;

        private float _invulnerabilityNextSeconds = 0f;

        public bool Invulnerability => _invulnerabilityNextSeconds > 0 || _invulnerability;
        protected UnityEvent Death => _death;
        
        public int Current
        {
            get
            {
                return _current;
            }
            private set
            {
                _current = Mathf.Clamp(value, 0, _max);
                _currentChanged.Invoke();
                if (_current <= 0)
                {
                    Death.Invoke();
                }
            }
        }
        public int Max => _max;

        public void Damage(int value)
        {
            if (Invulnerability == false)
            {
                Current -= value;
                _takeDamage.Invoke();
                AddInvulnerability(_invulnerabilityAfterDamage);
            }
        }

        public void AddInvulnerability(float onSeconds)
        {
            _invulnerabilityNextSeconds += onSeconds;
        }

        public void Heal(int value)
        {
            Current += value;
            _gotHeal.Invoke();
        }

        private void FixedUpdate()
        {
            _invulnerabilityNextSeconds = Mathf.Clamp(_invulnerabilityNextSeconds - Time.fixedDeltaTime, 0, Mathf.Infinity);
        }
    }
}