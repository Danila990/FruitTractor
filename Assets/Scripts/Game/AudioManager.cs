using System;
using System.Linq;
using UnityEngine;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private SoundData[] _sounds;
        [SerializeField] private AudioSource _sound;
        [SerializeField] private AudioSource _music;

        public bool IsMusicMute => _music.mute;
        public bool IsSoundMute => _sound.mute;

        public void SetSoundMute(bool state)
        {
            _sound.mute = state;
        }
        public void SetMusicMute(bool state)
        {
            _music.mute = state;
        }

        public void Play(int id)
        {
            SoundData soundData = GetSoundData(id);
            _sound.PlayOneShot(soundData._audioClip, soundData._volume);
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