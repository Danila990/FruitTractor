using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class SoundButton : UIButton
    {
        [SerializeField] private Sprite _offState;
        [SerializeField] private Image _image;

        private Sprite _onState;

        [Inject]
        private void Construct(AudioManager audioManager)
        {
            _audioManager = audioManager;
        }

        protected override void Start()
        {
            base.Start();

            _image = GetComponent<Image>();
            _onState = _image.sprite;
            ChangeSprite();
        }

        protected override void OnClick()
        {
            base.OnClick();

            _audioManager.SetSoundMute(!_audioManager.IsSoundMute);
            ChangeSprite();
        }

        private void ChangeSprite()
        {
            if (!_audioManager.IsSoundMute)
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