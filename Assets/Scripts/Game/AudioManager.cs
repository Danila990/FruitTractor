using System.Linq;
using UnityEngine;

namespace Manager
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private SoundData[] _sounds;
        [SerializeField] private AudioClip _buttonClip;
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

        private void Play(string id)
        {
            SoundData soundData = GetSoundData(id);
            _sound.PlayOneShot(soundData._audioClip, soundData._volume);
        }

        private SoundData GetSoundData(string id)
        {
            return _sounds.FirstOrDefault(sound => sound._id == id);
        }
    }

    public class SoundData
    {
        [field: SerializeField] public string _id { get; private set; }
        [field: SerializeField] public AudioClip _audioClip { get; private set; }
        [field: SerializeField] public float _volume { get; private set; }
    }
}