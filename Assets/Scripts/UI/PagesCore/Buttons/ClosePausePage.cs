using UnityEngine;
using Zenject;

namespace Code
{
    public class ClosePausePage : UIButton
    {
        [SerializeField] private string _pageId = "Pause";

        private PagesController _controller;
        private GameManager _gameManager;

        [Inject]
        private void Construct(PagesController pagesController, GameManager gameManager)
        {
            _gameManager = gameManager;
            _controller = pagesController;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _gameManager.PlayGame();
            _controller.ShowPage(_pageId);
        }
    }
}