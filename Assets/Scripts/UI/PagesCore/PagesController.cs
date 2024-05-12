using System.Linq;
using UnityEngine;

namespace Code
{
    public class PagesController : MonoBehaviour
    {
        [SerializeField] private Page[] _pages;

        [field: SerializeField] public Page CurrentPage { set; private get; }

        public void ShowPage(string pageId)
        {
            CurrentPage?.Hide();
            CurrentPage = GetPage(pageId);
            CurrentPage.gameObject.SetActive(true);
            CurrentPage.Show();
        }

        public void HidePage()
        {
            CurrentPage?.Hide();
            CurrentPage = null;
        }

        private Page GetPage(string id)
        {
            Page findPage = _pages.FirstOrDefault(page => page._id == id);
            if (findPage == null)
            {
                Debug.LogError("Page Id error: " + id);
            }

            return findPage;
        }
    }
}