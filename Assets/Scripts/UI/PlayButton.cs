using Manager;
using UnityEngine;
using YG;

namespace UI
{
    public class PlayButton : MonoBehaviour
    {
        public void LoadGame()
        {
            AudioManager.Instance.PlayButtonAudio();
            SceneLoadManager.Instance.LoadGame(YandexGame.savesData.LevelComplete);
        }
    }
}