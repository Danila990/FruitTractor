using Zenject;

namespace Code
{
    public class FruitCell : Cell
    {
        private FruitController _fruitController;

        public Fruit _fruit { get; private set; }

        [Inject]
        private void Construct(FruitController fruitController)
        {
            _fruitController = fruitController;
        }

        private void Awake()
        {
            _fruit = GetComponentInChildren<Fruit>();
        }

        public override void CellEvent()
        {
            base.CellEvent();

            if(_fruit.gameObject.activeInHierarchy)
            {
                _fruitController.UpFruit(this);
            }
        }
    }
}