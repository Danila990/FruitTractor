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
        [SerializeField] private GamePagesController _pagesController;
        [SerializeField] private BasketFruitController _basketFruitController;

        public override void InstallBindings()
        {
            BindBootstrap();
            BindGame();
            BindInputService();
            BindControllers();
        }

        private void BindGame()
        {
            Container
                .Bind<GameManager>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<LevelTimer>()
                .FromInstance(_levelTimer)
                .AsSingle();
        }

        private void BindControllers()
        {
            Container
                .Bind<GridController>()
                .FromInstance(_gridController)
                .AsSingle();

            Container
                .Bind<FruitController>()
                .FromNew()
                .AsSingle();

            Container
                .Bind<PagesController>()
                .FromInstance(_pagesController)
                .AsSingle();

            Container
                .Bind<BasketFruitController>()
                .FromInstance(_basketFruitController)
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