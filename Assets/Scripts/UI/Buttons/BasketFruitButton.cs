using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class BasketFruitButton : UIButton
    {
        [SerializeField] private Image _icon;

        private FruitType _fruitType;
        private Button _button;
        private BasketFruitController _basketFruit;
        
        public void SetupButton(FruitType fruitType, Sprite icon, BasketFruitController basketFruit)
        {
            _button = GetComponent<Button>();
            _basketFruit = basketFruit;
            _fruitType = fruitType;
            _icon.sprite = icon;
        }
        
        public void ChangeInteractable(bool state) => _button.interactable = state;
        
        protected override void OnClick()
        {
            base.OnClick();

            _basketFruit.SetCurrentFruitType(_fruitType, this);
        }
    }
}