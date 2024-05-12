using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using Zenject;

namespace Code
{
    public class LoadNextLevelButton : UIButton
    {
        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        protected override void Start()
        {
            base.Start();

            SavesYG savesYG = YandexGame.savesData;
            if (savesYG.CurrentLevel == savesYG._maxLevel || SceneManager.sceneCountInBuildSettings == savesYG.CurrentLevel)
            {
                GetComponent<Button>().interactable = false;
            }
        }

        protected override void OnClick()
        {
            base.OnClick();

            _sceneLoader.LoadNextLevel();
        }
    }
}