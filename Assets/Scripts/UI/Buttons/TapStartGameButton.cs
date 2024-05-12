using System.Collections;
using UnityEngine;
using Zenject;

namespace Code
{
    public class TapStartGameButton : UIButton
    {
        [SerializeField] private string _pageId = "GUI";

        private LevelTimer _levelTimer;
        private PagesController _pagesController;
        private GameManager _gameManager;

        [Inject]
        private void Construct(LevelTimer levelTimer, PagesController pagesController, GameManager gameManager)
        {
            _gameManager = gameManager;
            _levelTimer = levelTimer;
            _pagesController = pagesController;
        }

        private void OnEnable()
        {
            _gameManager.PauseGame();
        }

        protected override void OnClick()
        {
            base.OnClick();

            _gameManager.PlayGame();
            _levelTimer.StartTimer();
            _pagesController.ShowPage(_pageId);
        }
    }
}