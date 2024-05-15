using System;
using Zenject;

namespace Code
{
    public class FruitController : IInitializable
    {
        public event Action<int> OnCountFruits;
        public event Action<FruitType> OnUpFruit;

        private GridController _gridController;
        private GameManager _gameManager;
        private AudioController _audioManager;

        public int _countFruit { get; private set; }

        [Inject]
        private void Construct(GridController controller, GameManager gameManager, AudioController audioManager)
        {
            _gridController = controller;
            _gameManager = gameManager;
            _audioManager = audioManager;
        }

        public void Initialize()
        {
            _countFruit = _gridController._fruits.Count;
        }

        public void UpFruit(FruitCell cell)
        {
            cell._fruit.DeactivateFruit();
            _countFruit -= 1;
            _audioManager.Play(2);
            OnCountFruits?.Invoke(_countFruit);
            OnUpFruit?.Invoke(cell._fruit._fruitType);
            if (_countFruit == 0)
            {
                _gameManager.WinGame();
            }
        }
    }
}