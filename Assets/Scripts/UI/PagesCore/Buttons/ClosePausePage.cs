using UnityEngine;
using Zenject;

namespace Code
{
    public class ClosePausePage : UIButton
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

            Time.timeScale = 1.0f;
            _controller.ShowPage(_pageId);
        }
    }
}