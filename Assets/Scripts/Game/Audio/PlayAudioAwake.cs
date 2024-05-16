using UnityEngine;
using Zenject;

namespace Code
{
    public class PlayAudioAwake : MonoBehaviour {
        [SerializeField] private int _audioIndex = 2;

        private AudioController _audioController;

        [Inject]
        private void Construct(AudioController audioController){
            _audioController = audioController;
        }

        private void Awake() {
            _audioController.Play(_audioIndex);
        }
    }
}