using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using Zenject;
using Random = UnityEngine.Random;

namespace Code
{
    public class GameManager
    {
        public bool _isPlayGame => Time.timeScale != 0;

        private SceneLoader _sceneLoader;
        private PagesController _pagesController;
        private LevelTimer _levelTimer;
        private Player _player;

        [Inject]
        private void Construct(SceneLoader sceneLoader, PagesController pagesController, LevelTimer levelTimer)
        {
            _levelTimer = levelTimer;
            _sceneLoader = sceneLoader;
            _pagesController = pagesController;
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
        
        public void ReviewGame()
        {
            YandexGame.RewardVideoEvent += OnShowAd;
            YandexGame.RewVideoShow(0);
        }

        public void LossGame()
        {
            PauseGame();
            _pagesController.ShowPage("Loss");
        }
        
        public void WinGame()
        {
            PauseGame();
            _pagesController.ShowPage("Win");
            SavesYG savesYG = YandexGame.savesData;
            if (savesYG.CurrentLevel < savesYG._maxLevel && savesYG.CurrentLevel == SceneManager.GetActiveScene().buildIndex)
            {
                savesYG.CurrentLevel += 1;
                YandexGame.SaveProgress();
            }
        }

        private void OnShowAd(int index)
        {
            YandexGame.RewardVideoEvent -= OnShowAd;
            _levelTimer.ReviewTimer(5);
            _pagesController.ShowPage("GUI");
            PlayGame();
        }
    }
}