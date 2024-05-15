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
        private Player _player;

        [Inject]
        private void Construct(LevelTimer levelTimer, PagesController pagesController, Player player)
        {
            _levelTimer = levelTimer;
            _pagesController = pagesController;
            _player = player;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _player.StartMove();
            _levelTimer.StartTimer();
            _pagesController.ShowPage(_pageId);
        }
    }
}