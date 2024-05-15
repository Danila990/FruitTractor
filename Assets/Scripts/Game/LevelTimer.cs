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
        private int _currentTime;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameManager.OnStartGame += StartTimer;
            _currentTime = _levelTime;
        }

        private void Awake()
        {
            OnLevelTime?.Invoke(_currentTime);
        }

        public void ReviewTimer(int addTime)
        {
            _currentTime = addTime;
            OnLevelTime?.Invoke(_currentTime);
            StartTimer();
        }

        private void StartTimer()
        {
            _gameManager.OnStartGame -= StartTimer;
            StopAllCoroutines();
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