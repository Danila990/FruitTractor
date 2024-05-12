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

        private bool _isFirstReview = true;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void OnEnable()
        {
            if (!_isFirstReview)
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