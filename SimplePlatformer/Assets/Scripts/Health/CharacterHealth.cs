using UnityEngine;
using UnityEngine.Events;

namespace Health
{
    public class CharacterHealth : MonoBehaviour
    {
        public bool Invulnerability = false;
        [SerializeField] private int _max = 3;
        [SerializeField] private int _current = 3;
        [SerializeField] private UnityEvent _death;
        [SerializeField] private UnityEvent _takeDamage;
        [SerializeField] private UnityEvent _gotHeal;
        [SerializeField] private UnityEvent _currentChanged;

        protected UnityEvent Death => _death;
        
        public int Current
        {
            get
            {
                return _current;
            }
            set
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
            }
        }

        public void Heal(int value)
        {
            Current += value;
            _gotHeal.Invoke();
        }
    }
}