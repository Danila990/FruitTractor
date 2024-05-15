using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    public class UIButton : MonoBehaviour
    {
        protected AudioController _audioManager;

        [Inject]
        private void Construct(AudioController audioManager)
        {
            _audioManager = audioManager;
        }

        protected virtual void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        protected virtual void OnDestroy()
        {
            GetComponent<Button>().onClick.RemoveListener(OnClick);
        }

        protected virtual void OnClick()
        {
            _audioManager.Play(0);
        }
    }
}