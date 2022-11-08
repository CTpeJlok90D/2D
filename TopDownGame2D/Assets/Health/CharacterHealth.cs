using UnityEngine;
using UnityEngine.Events;

namespace Health
{
    public class CharacterHealth : MonoBehaviour
    {
        public bool Invulnerability = false;
        [SerializeField] private int _max = 100;
        [SerializeField] private int _current = 100;
        [SerializeField] private UnityEvent _death = new UnityEvent();
        [SerializeField] private UnityEvent<int> _takeDamage = new UnityEvent<int>();
        [SerializeField] private UnityEvent<int> _gotHeal = new UnityEvent<int>();
        [SerializeField] private UnityEvent<int> _currentChanged = new UnityEvent<int>();

        protected UnityEvent Death => _death;

        public int Current
        {
            get => _current;
            set
            {
                if (value - _current >= 0)
                {
                    _gotHeal.Invoke(value - _current);
                }
                else
                {
                    _takeDamage.Invoke(value - _current);
                }
                _current = Mathf.Clamp(value, 0, _max);
                _currentChanged.Invoke(_current);
                if (_current <= 0)
                {
                    Death.Invoke();
                }
            }
        }
        public int Max => _max;
    }
}