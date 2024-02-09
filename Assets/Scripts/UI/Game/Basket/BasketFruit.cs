using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace UI.Game.Basket
{
    public class BasketFruit : MonoBehaviour, IInitGameSceneContext
    {
        [Serializable]
        private class BasketData
        {
            [field: SerializeField] public TypeFruit _Type { get; private set; }
            [field: SerializeField] public Sprite _Icon { get; private set; }
        }
        
        [SerializeField] private BasketFruitButton _fruitButtonPrefab;
        [SerializeField] private Transform _parentButton;
        [SerializeField] private BasketData[] _basketDatas;
        
        public TypeFruit _currentFruitType { get; private set; }
        private List<BasketFruitButton> _basketFruitsButton = new List<BasketFruitButton>();
        
        public void Init(GameSceneContext gameSceneContext)
        {
            gameSceneContext._gameManager.SubRestartEvent(Restart);
            CreateButtons(gameSceneContext._fruitGridController.GetFruitsType());
            Restart();
        }
        
        public void BasketFruitButtonClick(TypeFruit typeFruit, BasketFruitButton button)
        {
            foreach (BasketFruitButton fruitButton in _basketFruitsButton)
                fruitButton.ChangeInteractable(true);
            
            button.ChangeInteractable(false);
            _currentFruitType = typeFruit;
        }

        private void CreateButtons(List<TypeFruit> typeFruit)
        {
            foreach (TypeFruit type in typeFruit)
            {
                BasketData data = GetButtonData(type);
                
                BasketFruitButton basketFruitButton = Instantiate(_fruitButtonPrefab, _parentButton);
                basketFruitButton.SetupButton(data._Type, data._Icon, this);
                _basketFruitsButton.Add(basketFruitButton);
            }
        }
        
        private BasketData GetButtonData(TypeFruit needType)
        {
            foreach (BasketData data in _basketDatas)
            {
                if (data._Type == needType)
                    return data;
            }
            Debug.LogError("No need fruit type");
            return null;
        }

        private void Restart()
        {
            BasketFruitButtonClick(_basketFruitsButton[0]._FruitType, _basketFruitsButton[0]);
        }
    }
}