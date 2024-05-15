using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

namespace Code
{
    public class SceneLoader
    {
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
            Time.timeScale = 1.0f;
            LoadGame(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadNextLevel()
        {
            Time.timeScale = 1.0f;
            LoadGame(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}