using Manager;
using UnityEngine;

namespace UI
{
    public class OpenCloseUi : MonoBehaviour
    {
        [SerializeField] private GameObject _open;
        [SerializeField] private GameObject _close;

        public void OpenClose()
        {
            //AudioManager.Instance.PlayButtonAudio();
            _close.SetActive(false);
            _open.SetActive(true);
        }
    }
}