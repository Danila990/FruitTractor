using Code;
using UnityEngine;
using Zenject;

namespace Code
{
    public class OpenPausePageButton : UIButton
    {
        [SerializeField] private string _pageId = "Pause";

        private PagesController _controller;

        [Inject]
        private void Construct(PagesController pagesController)
        {
            _controller = pagesController;
        }

        protected override void OnClick()
        {
            base.OnClick();

            Time.timeScale = 0;
            _controller.ShowPage(_pageId);
        }
    }
}