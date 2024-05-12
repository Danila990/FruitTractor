using System;
using UnityEngine;
using Zenject;

namespace Code
{
    public class GameManager
    {
        public bool _isPlayGame => Time.timeScale != 0;

        private SceneLoader _sceneLoader;
        private PagesController _pagesController;

        [Inject]
        private void Construct(SceneLoader sceneLoader, PagesController pagesController)
        {
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
        
        public void LossGame()
        {
            PauseGame();
            _pagesController.ShowPage("Loss");
        }
        
        public void WinGame()
        {
            PauseGame();
            _pagesController.ShowPage("Win");
        }
    }
}