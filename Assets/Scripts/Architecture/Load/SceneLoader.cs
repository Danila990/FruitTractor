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
            if(SceneManager.sceneCountInBuildSettings <= indexLoad || YandexGame.savesData._maxLevel < indexLoad)
            {
                return;
            }

            SceneManager.LoadScene(indexLoad);
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextLevel()
        {
            LoadGame(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}