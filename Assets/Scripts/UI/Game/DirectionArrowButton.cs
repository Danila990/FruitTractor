using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class DirectionArrowButton : UIButton
    {
        [field: SerializeField] public DirectionType _directionType { get; private set; }

        private DirectionArrow _directionArrow;
        private Button _button;

        protected override void Start()
        {
            base.Start();

            _directionArrow = GetComponentInParent<DirectionArrow>();
            _button = GetComponent<Button>();
        }

        protected override void OnClick()
        {
            base.OnClick();

            _directionArrow.OnCLickDirectionButton(this);
        }

        public void ChangeInteractable(bool state) => _button.interactable = state;
    }
}