using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using GameGrid.GridObject;
using Manager;
using Player;
using UI.Game;
using UI.Game.Basket;
using UnityEngine;

namespace GameGrid.Controllers
{
    public class FruitGridController : MonoBehaviour, IInitGameSceneContext
    {
        [SerializeField] private FruitCounter _fruitCounter;
        
        private Dictionary<Vector2Int, Fruit> _fruits = new Dictionary<Vector2Int, Fruit>();
        private GameManager _gameManager;
        private BasketFruit _basketFruit;
        
        public int CountFruit => _fruits.Count;
        
        public void Init(GameSceneContext gameSceneContext)
        {
            _fruits = gameSceneContext._levelGridCreator.FruitGridSpawner.GetFruits();
            _basketFruit = gameSceneContext._basketFruit;
            _gameManager = gameSceneContext._gameManager;
            
            PlayerController.Instance.OnCurrentCell += CheckFruit;
            gameSceneContext._gameManager.SubRestartEvent(Restart);
        }

        public List<TypeFruit> GetFruitsType()
        {
            List<TypeFruit> fruits = new List<TypeFruit>(_fruits.Count);

            foreach (Fruit fruit in _fruits.Values)
            {
                fruits.Add(fruit._type);
            }

            List<TypeFruit>  resultSortTypes = fruits.Distinct().ToList();
            resultSortTypes.Sort();
            
            return resultSortTypes;
        }
        
        private void CheckFruit(GridCell gridCell)
        {
             if(!gridCell._typeCell.Equals(TypeCell.Fruit)) return;

             foreach (var fruit in _fruits)
             {
                 if (fruit.Key == gridCell._gridIndex && fruit.Value.gameObject.activeSelf)
                 {
                     if (_basketFruit._currentFruitType != fruit.Value._type)
                     {
                         _gameManager.LossEvent();
                         return;
                     }
                     
                     _fruitCounter.AddFruit();
                     fruit.Value.DeactivateFruit();
                     return;
                 }
             }
        }

        private void Restart()
        {
            foreach (Fruit fruit in _fruits.Values)
            {
                fruit.RestartAnim();
                fruit.gameObject.SetActive(true);
            }
        }
        
        private void OnDestroy() => PlayerController.Instance.OnCurrentCell -= CheckFruit;
    }
}