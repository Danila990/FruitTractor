using Zenject;

namespace Code
{
    public class Bootstrap : IInitializable
    {
        private FruitController _fruitController;
        private GridController _gridController;
        private BasketFruitController _basketFruit;

        [Inject]
        private void Construct(FruitController fruitController, GridController gridController, BasketFruitController basketFruit)
        {
            _basketFruit = basketFruit;
            _gridController = gridController;
            _fruitController = fruitController;
        }

        public void Initialize()
        {
            _gridController.Initialize();
            _fruitController.Initialize();
            _basketFruit.Initialize();
        }
    }
}