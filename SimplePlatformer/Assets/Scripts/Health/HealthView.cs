using UnityEngine;
using UnityEngine.UI;

namespace Health
{
    public class HealthView : MonoBehaviour 
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private EntityHealth _health;

        public void UpdateSlider()
        {
            _slider.value = _health.Current;
        } 

        private void Awake() 
        {
            _slider.maxValue = _health.Max;
            UpdateSlider();
        }
    }
}