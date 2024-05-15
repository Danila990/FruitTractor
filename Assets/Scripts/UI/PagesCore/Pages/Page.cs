using UnityEngine;

namespace Code
{
    public class Page : MonoBehaviour
    {
        [field: SerializeField] public PageType _pageType { get; private set; }

        private AlphaAnimation _alphaAnimator;

        protected virtual void Awake()
        {
            _alphaAnimator = GetComponent<AlphaAnimation>();
        }

        public virtual void Show()
        {
            _alphaAnimator.Show();
        }

        public virtual void Hide()
        {
            _alphaAnimator.Hide();
        }
    }
}