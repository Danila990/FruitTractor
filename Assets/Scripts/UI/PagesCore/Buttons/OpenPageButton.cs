using Code;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    [RequireComponent(typeof(Button))]
    public class OpenPageButton : UIButton
    {
        [SerializeField] private string _pageId;

        private PagesController _controller;

        [Inject]
        private void Construct(PagesController pagesController)
        {
            _controller = pagesController;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _controller.ShowPage(_pageId);
        }
    }
}