using UnityEngine;
using Zenject;

namespace Code
{
    public class Bootstrap : IInitializable, ILateDisposable
    {
        private FruitController _fruitController;

        [Inject]
        private void Construct(FruitController fruitController)
        {
            _fruitController = fruitController;
        }

        public void Initialize()
        {
            _fruitController.Initialize();
        }

        public void LateDispose()
        {
            _fruitController.LateDispose();
        }
    }
}