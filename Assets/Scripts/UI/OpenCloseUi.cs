using Code;
using Manager;
using UnityEngine;

namespace Code
{
    public class OpenCloseUi : UIButton
    {
        [SerializeField] private GameObject _open;
        [SerializeField] private GameObject _close;

        protected override void OnClick()
        {
            base.OnClick();

            _close.SetActive(false);
            _open.SetActive(true);
        }
    }
}