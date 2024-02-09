using System;
using System.Collections.Generic;
using Enums;
using GameGrid.GridObject;
using Manager;
using Player;
using UnityEngine;

namespace GameGrid.Controllers
{
    public class FruitGridController : MonoBehaviour, IInitGameSceneContext
    {
        private Dictionary<Vector2Int, Fruit> _fruits = new Dictionary<Vector2Int, Fruit>();
        private GameManager _gameManager;
        
        public void Init(GameSceneContext gameSceneContext)
        {
            _fruits = gameSceneContext._levelGridCreator.FruitGridSpawner.GetFruits();
            
            PlayerController.Instance.OnCurrentCell += CheckFruit;
            gameSceneContext._gameManager.SubRestartEvent(Restart);
        }

        private void CheckFruit(GridCell gridCell)
        {
             if(!gridCell._typeCell.Equals(TypeCell.Fruit)) return;

             foreach (var fruit in _fruits)
             {
                 if (fruit.Key == gridCell._gridIndex)
                 {
                     fruit.Value.gameObject.SetActive(false);
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