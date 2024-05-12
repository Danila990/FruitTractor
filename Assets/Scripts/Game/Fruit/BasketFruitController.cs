using System;
using System.Collections.Generic;
using System.Linq;
using Code;
using UnityEngine;
using Zenject;

namespace Code
{
    public class BasketFruitController : MonoBehaviour, IInitializable
    {
        [Serializable]
        private class BasketData
        {
            [field: SerializeField] public FruitType _fruitType { get; private set; }
            [field: SerializeField] public Sprite _fruitIcon { get; private set; }
        }
        
        [SerializeField] private BasketFruitButton _fruitButtonPrefab;
        [SerializeField] private Transform _parentButton;
        [SerializeField] private BasketData[] _basketDatas;
        
        private List<BasketFruitButton> _basketFruitsButton = new List<BasketFruitButton>();
        private FruitType _currentFruitType;
        private GridController _gridController;
        private GameManager _gameManager;
        private Dictionary<Vector2Int, Fruit> _fruits = new Dictionary<Vector2Int, Fruit>();

        [Inject]
        private void Construct(GridController gridController, GameManager gameManager)
        {
            _gameManager = gameManager;
            _gridController = gridController;
            _gridController.OnCellEvent += CurrentCell;
        }

        public void Initialize()
        {
            _fruits = _gridController._fruits;
            CreateButtons();
        }

        private void CurrentCell(Cell currentCell)
        {
            if (_fruits.TryGetValue(currentCell._gridIndex, out Fruit findFruit))
            {
                if (findFruit._fruitType != _currentFruitType)
                {
                    _gameManager.LossGame();
                }
            }
        }

        public void SetCurrentFruitType(FruitType typeFruit, BasketFruitButton button)
        {
            foreach (BasketFruitButton fruitButton in _basketFruitsButton)
                fruitButton.ChangeInteractable(true);
            
            button.ChangeInteractable(false);
            _currentFruitType = typeFruit;
        }

        private void CreateButtons()
        {
            List<FruitType> uniqueFruitTypes = _fruits.Values
            .Select(fruit => fruit._fruitType)
            .Distinct()
            .ToList();
            foreach (FruitType type in uniqueFruitTypes)
            {
                BasketData data = _basketDatas.FirstOrDefault(data => data._fruitType == type);
                BasketFruitButton basketFruitButton = Instantiate(_fruitButtonPrefab, _parentButton);
                basketFruitButton.SetupButton(data._fruitType, data._fruitIcon, this);
                _basketFruitsButton.Add(basketFruitButton);
            }

            SetCurrentFruitType(uniqueFruitTypes[0], _basketFruitsButton[0]);
        }
    }
}