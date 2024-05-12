﻿using System.Collections;
using UnityEngine;
using Zenject;

namespace Code
{
    public class TapStartGameButton : UIButton
    {
        [SerializeField] private string _pageId = "GUI";

        private LevelTimer _levelTimer;
        private PagesController _pagesController;

        [Inject]
        private void Construct(LevelTimer levelTimer, PagesController pagesController)
        {
            _levelTimer = levelTimer;
            _pagesController = pagesController;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _levelTimer.StartTimer();
            _pagesController.ShowPage(_pageId);
        }
    }
}