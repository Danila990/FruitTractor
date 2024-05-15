using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class MusicButton : UIButton
    {
        [SerializeField] private Sprite _offState;
        [SerializeField] private Image _image;

        private Sprite _onState;

        [Inject]
        private void Construct(AudioController audioManager)
        {
            _audioManager = audioManager;
        }

        protected override void Start()
        {
            base.Start();

            _onState = _image.sprite;
            ChangeSprite();
        }

        protected override void OnClick()
        {
            base.OnClick();

            _audioManager.SetMusicMute(!_audioManager.IsMusicMute);
            ChangeSprite();
        }

        private void ChangeSprite()
        {
            if (!_audioManager.IsMusicMute)
            {
                _image.sprite = _onState;
            }
            else
            {
                _image.sprite = _offState;
            }
        }
    }
}