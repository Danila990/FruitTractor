using System.Linq;
using UnityEngine;

namespace Code
{
    public class PagesController : MonoBehaviour
    {
        [SerializeField] private Page _currentPage;
        [SerializeField] private Page[] _pages;
  
        public void ShowPage(PageType pageType)
        {
            _currentPage?.Hide();
            _currentPage = GetPage(pageType);
            _currentPage.gameObject.SetActive(true);
            _currentPage.Show();
        }

        public void HidePage()
        {
            _currentPage?.Hide();
            _currentPage = null;
        }

        private Page GetPage(PageType pageType)
        {
            Page returnPage = _pages.FirstOrDefault(page => page._pageType == pageType);
            if (returnPage == null)
            {
                Debug.LogError("Page Error: " + pageType);
            }

            return returnPage;
        }
    }
}