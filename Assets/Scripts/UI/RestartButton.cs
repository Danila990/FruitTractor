using Zenject;

namespace Code
{
    public class RestartButton : UIButton
    {
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _gameManager.RestartGame();
        }
    }
}