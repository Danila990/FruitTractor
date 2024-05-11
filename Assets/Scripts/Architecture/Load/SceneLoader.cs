using UnityEngine.SceneManagement;
using YG;

namespace Code
{
    public class SceneLoader
    {
        public void LoadHome()
        {
            SceneManager.LoadScene(0);
        }
        
        public void LoadGame(int indexLoad)
        {
            if(SceneManager.sceneCount < indexLoad || YandexGame.savesData._maxLevel < indexLoad)
            {
                return;
            }
            SceneManager.LoadScene(indexLoad);
        }
    }
}