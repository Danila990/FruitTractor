using System;
using Code;
using Enums;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Game.Basket
{
    public class BasketFruitButton : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        
        public FruitType _FruitType { get; private set; }
        private Button _button;
        private BasketFruit _basketFruit;
        
        public void SetupButton(FruitType fruitType, Sprite icon, BasketFruit basketFruit)
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ClickButton);
            _basketFruit = basketFruit;
            
            _FruitType = fruitType;
            _icon.sprite = icon;
        }
        
        public void ChangeInteractable(bool state) => _button.interactable = state;
        
        private void ClickButton()
        {
            //AudioManager.Instance.PlayButtonAudio();
            _basketFruit.BasketFruitButtonClick(_FruitType, this);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ClickButton);
        }
    }
}