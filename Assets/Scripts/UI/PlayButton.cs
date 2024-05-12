using YG;
using Zenject;

namespace Code
{
    public class PlayButton : UIButton
    {
        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        protected override void OnClick()
        {
            base.OnClick();

            _sceneLoader.LoadGame(YandexGame.savesData.CurrentLevel);
        }
    }
}