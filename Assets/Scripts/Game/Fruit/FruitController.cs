using System;
using Zenject;

namespace Code
{
    public class FruitController : IInitializable
    {
        public event Action<int> OnCountFruits;

        private GridController _gridController;
        private GameManager _gameManager;
        private AudioController _audioManager;
        private BasketFruitController _basketFruitController;

        public int _countFruit { get; private set; }

        [Inject]
        private void Construct(GridController controller, GameManager gameManager, AudioController audioManager, BasketFruitController basketFruitController)
        {
            _gridController = controller;
            _gameManager = gameManager;
            _audioManager = audioManager;
            _basketFruitController = basketFruitController;
        }

        public void Initialize()
        {
            _countFruit = _gridController._fruits.Count;
        }

        public void UpFruit(FruitCell cell)
        {
            cell._fruit.DeactivateFruit();
            if (_basketFruitController._currentFruitType == cell._fruit._fruitType)
            {
                _countFruit -= 1;
                _audioManager.Play(2);
                OnCountFruits?.Invoke(_countFruit);
                if (_countFruit == 0)
                {
                    _gameManager.WinGame();
                }
            }
            else
            {
                _gameManager.LossGame(); 
            }

            
        }
    }
}