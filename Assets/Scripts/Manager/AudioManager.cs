using UnityEngine;

namespace Manager
{
    public class AudioManager : SingletonPersistent<AudioManager>
    {
        [SerializeField] private AudioSource _button;
        [SerializeField] private AudioSource _fruit;
        [SerializeField] private AudioSource _background;

        public bool IsBackgroundMut => _background.mute;

        public void PlayButtonAudio()
        {
            Destroy(Instantiate(_button).gameObject, 0.2f);
        }

        public void PlayFruitAudion()
        {
            Destroy(Instantiate(_fruit).gameObject, 0.4f);
        }

        public void SetMutBackgroundAudio(bool state)
        {
            _background.mute = state;
        }
    }
}