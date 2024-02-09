using Manager;
using UnityEngine;

namespace UI
{
    public class LevelButton : MonoBehaviour
    {
        public void ClickButton(int index)
        {
            AudioManager.Instance.PlayButtonAudio();
            SceneLoadManager.Instance.LoadGame(index);
        }
    }
}