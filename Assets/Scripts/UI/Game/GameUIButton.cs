using System;
using Enums;
using Manager;
using UI.Game;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace UI
{
    public class GameUIButton : MonoBehaviour
    {
        [SerializeField] private MenuController _menuController;
        
        [Header("Tap Canvas")]
        [SerializeField] private Button _tapButton;
        [Header("Gui Canvas")]
        [SerializeField] private Button _pauseButton;
        [Header("Pause Canvas")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _restarPausetButton;
        [SerializeField] private Button _homePauseButton;
        [Header("Win Canvas")]
        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _homeWinButton;
        [Header("Loss Canvas")]
        [SerializeField] private Button _homeLossButton;
        [SerializeField] private Button _restartLossButton;
        
        private GameManager _gameManager;
        private AudioManager _audioManager;
        
        private void Start()
        {
            _gameManager = GameSceneContext.Instance._gameManager;
            _audioManager = AudioManager.Instance;
            BindButton();
        }
        
        private void OnDestroy()
        {
            _tapButton.onClick.RemoveListener(PlayClick);
            _pauseButton.onClick.RemoveListener(PauseClick);
            _playButton.onClick.RemoveListener(PlayClick);
            _restarPausetButton.onClick.RemoveListener(RestartCLick);
            _homePauseButton.onClick.RemoveListener(LoadHomeClick);
            _nextButton.onClick.RemoveListener(LoadNextLevel);
            _homeWinButton.onClick.RemoveListener(LoadHomeClick);
            _homeLossButton.onClick.RemoveListener(LoadHomeClick);
            _restartLossButton.onClick.RemoveListener(RestartCLick);
        }

        private void BindButton()
        {
            _tapButton.onClick.AddListener(PlayClick);
            _pauseButton.onClick.AddListener(PauseClick);
            _playButton.onClick.AddListener(PlayClick);
            _restarPausetButton.onClick.AddListener(RestartCLick);
            _homePauseButton.onClick.AddListener(LoadHomeClick);
            _nextButton.onClick.AddListener(LoadNextLevel);
            _homeWinButton.onClick.AddListener(LoadHomeClick);
            _homeLossButton.onClick.AddListener(LoadHomeClick);
            _restartLossButton.onClick.AddListener(RestartCLick);
        }
        
        private void PlayClick()
        {
            _audioManager.PlayButtonAudio();
            _menuController.OpenMenu(TypeMenu.Game);
            _gameManager.PlayEvent();
        }

        private void PauseClick()
        {
            _audioManager.PlayButtonAudio();
            _menuController.OpenMenu(TypeMenu.Pause);
            _gameManager.PauseEvent();
        }
        
        private  void RestartCLick()
        {
            YandexGame.FullscreenShow();
            
            _audioManager.PlayButtonAudio();
            _menuController.OpenMenu(TypeMenu.Game);
            _gameManager.RestartEvent();
        }
        
        private void LoadHomeClick()
        {
            _audioManager.PlayButtonAudio();
            SceneLoadManager.Instance.LoadHome();
        }

        private void LoadNextLevel()
        {
            _audioManager.PlayButtonAudio();
            if (SceneLoadManager.Instance._currentLoadScene + 1 == YandexGame.savesData._maxLevel)
                SceneLoadManager.Instance.LoadHome();
            
            SceneLoadManager.Instance.LoadGame(SceneLoadManager.Instance._currentLoadScene + 1);
        }
    }
}