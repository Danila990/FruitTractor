using System;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AudioButton : MonoBehaviour
    {
        [SerializeField] private Sprite _enableSprite;

        private Sprite _disableSprite;
        private Image _icon;
        private AudioManager _audioManager;

        private void Start()
        {
            _icon = GetComponent<Image>();
            _disableSprite = _icon.sprite;
            _audioManager = AudioManager.Instance;
            
            
            if (_audioManager.IsBackgroundMut)
                _icon.sprite = _disableSprite;
            else
                _icon.sprite = _enableSprite;
        }

        public void ChangeAudio()
        {
            if (_audioManager.IsBackgroundMut)
            {
                _icon.sprite = _enableSprite;
                _audioManager.SetMutBackgroundAudio(false);
            }
            else
            {
                _icon.sprite = _disableSprite;
                _audioManager.SetMutBackgroundAudio(true);
            }
        }
    }
}