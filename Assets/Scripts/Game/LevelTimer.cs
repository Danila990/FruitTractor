using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Code
{
    public class LevelTimer : MonoBehaviour
    {
        public event Action<int> OnLevelTime;

        [SerializeField] private int _levelTime;

        private GameManager _gameManager;

        public int _currentTime { get; private set; }

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
            _currentTime = _levelTime;
        }

        public void ReviewTimer(int addTime)
        {
            _currentTime = addTime;
            OnLevelTime?.Invoke(_currentTime);
            StartTimer();
        }

        public void StartTimer()
        {
            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1);
                _currentTime -= 1;
                OnLevelTime?.Invoke(_currentTime);
            }

            _gameManager.LossGame();
        }
    }
}