using System;
using UnityEngine;

namespace Code
{
    public class GameManager
    {
        public event Action OnLoss;
        public event Action OnWin;
        public event Action OnStart;

        public bool _isPlayGame => Time.timeScale != 0;

        public void RestartGame()
        {
            
        }
        
        public void PlayGame()
        {
            Time.timeScale = 1;
        }
        
        public void PauseGame()
        {
            Time.timeScale = 0;
        }
        
        public void StartGame()
        {
            PlayGame();
            OnStart?.Invoke();
        }

        public void LossEvent()
        {
            PauseGame();
            OnLoss?.Invoke();
        }
        
        public void WinEvent()
        {
            PauseGame();
            OnWin?.Invoke();
        }
    }
}