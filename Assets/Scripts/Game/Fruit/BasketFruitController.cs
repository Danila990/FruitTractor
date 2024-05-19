using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Code
{
    public class BasketFruitController : MonoBehaviour, IInitializable
    {
        [SerializeField] private Transform _parentButton;
        [SerializeField] private BasketContainer _basketContainer;

        private List<BasketButton> _basketButton = new List<BasketButton>();
        private GridController _gridController;

        public FruitType _currentFruitType { get; private set; }

        [Inject]
        private void Construct(GridController gridController)
        {
            _gridController = gridController;
        }

        public void Initialize()
        {
            CreateButtons(_gridController._fruits);
        }

        public void SetFruitType(FruitType typeFruit, BasketButton button)
        {
            foreach (BasketButton fruitButton in _basketButton)
            {
                fruitButton.ChangeInteractable(true);
            }
            
            button.ChangeInteractable(false);
            _currentFruitType = typeFruit;
        }

        private void CreateButtons(List<FruitCell> fruits)
        {
            List<FruitType> allFruitTypes = fruits.Select(fruitCell => fruitCell._fruit._fruitType)
                .Distinct().ToList();
            foreach (FruitType fruitType in allFruitTypes)
            {
                BasketButton newButton = Instantiate(_basketContainer._basketButtonPrefab, _parentButton);
                BasketButtonData basketData = _basketContainer.GetBasketData(fruitType);
                newButton.SetupData(basketData._fruitType, basketData._fruitIcon, this);
                _basketButton.Add(newButton);
            }

            SetFruitType(allFruitTypes[0], _basketButton[0]);
        }
    }
}