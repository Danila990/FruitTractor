using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
    [RequireComponent(typeof(Button))]
    public class OpenPageButton : UIButton
    {
        [SerializeField] private PageType _openPageType;

        private PagesController _controller;

        [Inject]
        private void Construct(PagesController pagesController)
        {
            _controller = pagesController;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _controller.ShowPage(_openPageType);
        }
    }
}