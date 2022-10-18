using UnityEngine;
using UnityEngine.Events;

namespace Health
{
    public class CharacterHealth : MonoBehaviour
    {
        public bool Invulnerability = false;
        [SerializeField] private int _max = 3;
        [SerializeField] private int _current = 3;
        [SerializeField] private UnityEvent _death = new();
        [SerializeField] private UnityEvent _takeDamage = new();
        [SerializeField] private UnityEvent _gotHeal = new();
        [SerializeField] private UnityEvent _currentChanged = new();

        protected UnityEvent Death => _death;
        
        public int Current
        {
            get => _current;
            set
            {
                if (value - _current >= 0)
                {
                    _gotHeal.Invoke();
                }
                else
                {
                    _takeDamage.Invoke();
                }
                _current = Mathf.Clamp(value, 0, _max);
                _currentChanged.Invoke();
                if (_current <= 0)
                {
                    Death.Invoke();
                }
            }
        }
        public int Max => _max;
    }
}