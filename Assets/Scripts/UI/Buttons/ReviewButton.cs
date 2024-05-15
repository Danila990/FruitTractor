using Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;

namespace Code
{
    public class ReviewButton :UIButton
    {
        private GameManager _gameManager;
        private FruitController _fruitController;

        private bool _isFirstReview = true;

        [Inject]
        private void Construct(GameManager gameManager, FruitController fruitController)
        {
            _gameManager = gameManager;
            _fruitController = fruitController;
        }

        private void OnEnable()
        {
            if (!_isFirstReview || _fruitController._countFruit == 0)
            {
                GetComponent<Button>().interactable = false;
            }
        }

        protected override void OnClick()
        {
            base.OnClick();

            if(_isFirstReview )
            {
                _gameManager.ReviewGame();
                _isFirstReview = false;
            }
        }
    }
}