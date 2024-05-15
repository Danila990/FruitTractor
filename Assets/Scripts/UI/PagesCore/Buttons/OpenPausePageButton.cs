using Zenject;

namespace Code
{
    public class OpenPausePageButton : UIButton
    {
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

            _gameManager.PauseGame();
            _controller.ShowPage(PageType.Game_Pause);
        }
    }
}