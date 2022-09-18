using UnityEngine;
using UnityEngine.UI;

namespace Health
{
    internal class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Health _health;

        private void Awake()
        {
            UpdateView();
        }

        public void UpdateView()
        {
            _slider.value = _health.Current;
        }
    }
}
