using Code;
using Zenject;

namespace Code
{
    public class LevelButton : UIButton
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

            _sceneLoader.LoadGame(LoadSceneIndex);
        }
    }
}