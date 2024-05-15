using Zenject;

namespace Code
{
    public class RockCell : Cell
    {
        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public override void CellEvent()
        {
            base.CellEvent();

            _gameManager.LossGame();
        }
    }
}