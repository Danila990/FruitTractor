using Zenject;

namespace Code
{
    public class TapStartGameButton : UIButton
    {
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

            _pagesController.ShowPage(PageType.Game_GUI);
            _gameManager.StartGame();
        }
    }
}