using Zenject;

namespace Code
{
    public class GamePagesController : PagesController
    {
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameManager.OnLossGame += OnLossGame;
            _gameManager.OnWinGame += OnWinGame;
        }

        private void OnDestroy()
        {
            _gameManager.OnLossGame -= OnLossGame;
            _gameManager.OnWinGame -= OnWinGame;
        }

        private void OnLossGame()
        {
            ShowPage(PageType.Game_Loss);
        }

        private void OnWinGame()
        {
            ShowPage(PageType.Game_Win);
        }
    }
}