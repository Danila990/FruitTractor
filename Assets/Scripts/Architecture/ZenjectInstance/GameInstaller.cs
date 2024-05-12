using UnityEngine;
using YG;
using Zenject;

namespace Code
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private bool _testPcInput = true;
        [SerializeField] private GridController _gridController;
        [SerializeField] private LevelTimer _levelTimer;

        public override void InstallBindings()
        {
            BindBootstrap();
            BindInputService();
            BindControllers();
            BindGameManager();
            BindLevelTimer();
            BindFruitController();
        }

        private void BindLevelTimer()
        {
            Container
                .Bind<LevelTimer>()
                .FromInstance(_levelTimer)
                .AsSingle();
        }

        private void BindGameManager()
        {
            Container
                .Bind<GameManager>()
                .FromNew()
                .AsSingle();
        }

        private void BindFruitController()
        {
            Container
                .Bind<FruitController>()
                .FromNew()
                .AsSingle();
        }

        private void BindControllers()
        {
            Container
                .Bind<GridController>()
                .FromInstance(_gridController)
                .AsSingle();
        }

        private void BindInputService()
        {
            if (_testPcInput || YandexGame.EnvironmentData.isDesktop)
            {
                Container.
                    Bind<IInputService>()
                    .To<PcInputService>().
                    FromNewComponentOnNewGameObject()
                    .AsSingle();
            }
            else
            {
                Container.
                    Bind<IInputService>()
                    .To<MobileInputService>().
                    FromNewComponentOnNewGameObject()
                    .AsSingle();
            }
        }

        private void BindBootstrap()
        {
            Container
                .BindInterfacesTo<Bootstrap>()
                .FromNew()
                .AsSingle();
        }
    }
}