using System;
using System.Linq;
using UnityEngine;

namespace Code
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private SoundData[] _sounds;
        [SerializeField] private AudioSource _sound;
        [SerializeField] private AudioSource _music;

        public bool IsMusicMute { get; private set; } = false;
        public bool IsSoundMute { get; private set; } = false;

        private void Awake()
        {
            _music.mute = IsMusicMute;
        }

        public void SetSoundMute(bool state)
        {
            IsSoundMute = state;
        }
        public void SetMusicMute(bool state)
        {
            _music.mute = state;
            IsMusicMute = state;
        }

        public void Play(int id)
        {
            if (!IsSoundMute)
            {
                SoundData soundData = GetSoundData(id);
                _sound.PlayOneShot(soundData._audioClip, soundData._volume);
            }
        }

        private SoundData GetSoundData(int id)
        {
            return _sounds.FirstOrDefault(sound => sound._id == id);
        }
    }

    [Serializable]
    public class SoundData
    {
        [field: SerializeField] public int _id { get; private set; }
        [field: SerializeField] public AudioClip _audioClip { get; private set; }
        [field: SerializeField, Range(0,1)] public float _volume { get; private set; }
    }
}