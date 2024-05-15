using UnityEngine;
using Zenject;

namespace Code
{
    public class LoadSceneButton : UIButton
    {
        public int LoadSceneIndex;

        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        protected override void OnClick()
        {
            base.OnClick();

            Time.timeScale = 1.0f;
            _sceneLoader.LoadGame(LoadSceneIndex);
        }
    }
}