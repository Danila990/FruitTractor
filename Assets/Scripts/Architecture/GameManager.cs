using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;

namespace Code
{
    public class GameManager
    {
        public event Action OnStartGame;
        public event Action OnLossGame;
        public event Action OnWinGame;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void StartGame()
        {
            PlayGame();
            OnStartGame?.Invoke();
        }

        public void RestartGame()
        {
            PlayGame();
            _sceneLoader.RestartScene();
        }
        
        public void PlayGame()
        {
            Time.timeScale = 1;
        }
        
        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void LossGame()
        {
            PauseGame();
            OnLossGame?.Invoke();
        }
        
        public void WinGame()
        {
            SaveProgress();
            PauseGame();
            OnWinGame?.Invoke();
            
        }

        private void SaveProgress()
        {
            SavesYG savesYG = YandexGame.savesData;
            if (savesYG.CurrentLevel < savesYG._maxLevel && savesYG.CurrentLevel == SceneManager.GetActiveScene().buildIndex)
            {
                savesYG.CurrentLevel += 1;
                YandexGame.SaveProgress();
            }
        }
    }
}