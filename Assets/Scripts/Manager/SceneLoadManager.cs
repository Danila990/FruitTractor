using UnityEngine.SceneManagement;
using YG;

namespace Manager
{
    public class SceneLoadManager : SingletonPersistent<SceneLoadManager>
    {
        public int _currentLoadScene { get; private set; }

        public void LoadHome()
        {
            _currentLoadScene = 0;
            SceneManager.LoadScene("MainMenu");
        }
        
        public void LoadGame(int indexLoad)
        {
            if (YandexGame.savesData._maxLevel < indexLoad) return;
            _currentLoadScene = indexLoad;
            SceneManager.LoadScene("Game");
        }
    }
}