using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

            if (SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex)
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