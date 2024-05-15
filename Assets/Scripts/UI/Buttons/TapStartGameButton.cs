using UnityEngine;
using Zenject;

namespace Code
{
    public class TapStartGameButton : UIButton
    {
        [SerializeField] private string _pageId = "GUI";

        private PagesController _pagesController;
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager, PagesController pagesController, Player player)
        {
            _gameManager = gameManager;
            _pagesController = pagesController;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _pagesController.ShowPage(_pageId);
            _gameManager.StartGame();
        }
    }
}