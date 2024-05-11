using System.Collections.Generic;
using Zenject;

namespace Code
{
    public class FruitController : IInitializable, ILateDisposable
    {
        private List<Fruit> _fruits = new List<Fruit>();
        private GridController _gridController;

        [Inject]
        private void Construct(GridController controller)
        {
            _gridController = controller;
            _gridController.OnCellEvent += CheckFruit;
        }

        public void LateDispose()
        {
            _gridController.OnCellEvent -= CheckFruit;
        }

        public void Initialize()
        {
            foreach (var cell in _gridController.GetFruits())
            {
                _fruits.Add(cell.GetComponentInChildren<Fruit>());
            }
        }

        private void CheckFruit(Cell cell)
        {
            if (!cell.Equals(CellType.Fruit))
            {
                return;
            }

            foreach (var fruit in _fruits)
            {
                if(fruit.Equals(cell) && fruit.gameObject.activeInHierarchy)
                {
                    fruit.DeactivateFruit();
                }
            }
        }
    }
}