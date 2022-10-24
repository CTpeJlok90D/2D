using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MainMenu.Audio
{
    using static SettingsLoadList;
    public class AudioVolumeSettings : MonoBehaviour
    {
        [SerializeField] private Slider _volimeSlider;
        [SerializeField] private bool _useVolumeText = false;
        [SerializeField] private TMP_Text _volumeText;
        [SerializeField] private AudioType audioType;
        public void UpdateVolume(float newVolume)
        {
            PlayerPrefs.SetFloat(AudioToStringList[audioType], newVolume / 100);
            AudioVolumeChange.Invoke();
            UpdateView();
        }

        private void UpdateView()
        {
            int newVolume = (int)(PlayerPrefs.GetFloat(AudioToStringList[audioType]) * 100);
            _volimeSlider.value = newVolume;
            if (_useVolumeText)
            {
                _volumeText.text = newVolume.ToString();
            }
        }

        private void OnEnable()
        {
            UpdateView();
            _volimeSlider.onValueChanged.AddListener(UpdateVolume);
        }

        private void OnDisable()
        {
            _volimeSlider.onValueChanged.RemoveListener(UpdateVolume);
        }
    }
}
