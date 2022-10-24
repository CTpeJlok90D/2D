using System.Collections.Generic;
using UnityEngine.Events;

namespace MainMenu
{
    static class SettingsLoadList
    {
        public static readonly UnityEvent AudioVolumeChange = new UnityEvent();
        public static readonly Dictionary<Audio.AudioType, string> AudioToStringList = new Dictionary<Audio.AudioType, string>()
        {
            [Audio.AudioType.Global] = "GlobalAudioVolume",
            [Audio.AudioType.Shooting] = "Shooting"
        };
    }
}
namespace MainMenu.Audio
{
    public enum AudioType
    {
        Global,
        Shooting
    }
}