using UnityEngine;

namespace MainMenu.Audio
{
    using static SettingsLoadList;
    using static PlayerPrefs;

    public class AudioApplyer : MonoBehaviour
    {
        [SerializeField] private AudioType _audioType;
        [SerializeField] private AudioSource _audioSource;

        public void UpdateAudioVolume()
        {
            _audioSource.volume = GetFloat(AudioToStringList[_audioType]) * GetFloat(AudioToStringList[AudioType.Global]);
        }

        private void Awake()
        {
            UpdateAudioVolume();
            AudioVolumeChange.AddListener(UpdateAudioVolume);
        }
    }
}
