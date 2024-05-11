using System;
using Manager;
using TMPro;
using UnityEngine;

namespace UI.Game
{
    public class FruitCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fruitText;
        
        private int _maxCount;
        private int _currentCount;
        private AudioManager _audioManager;

        /*private void Start()
        {
            GameSceneContext gameSceneContext = GameSceneContext.Instance;
            _audioManager = AudioManager.Instance;
            _maxCount = gameSceneContext._fruitGridController.CountFruit;
            Restart();
            
            gameSceneContext._gameManager.SubRestartEvent(Restart);
        }
        
        public void AddFruit()
        {
            _audioManager.PlayFruitAudion();
            _currentCount++;
            OutputFruit();
            if (_currentCount == _maxCount)
                GameSceneContext.Instance._gameManager.WinEvent();
        }

        private void OutputFruit() => _fruitText.text = $"{_currentCount}/{_maxCount}";

        private void Restart()
        {
            _currentCount = 0;
            OutputFruit();
        }*/
    }
}