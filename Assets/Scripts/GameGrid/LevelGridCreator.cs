using GameGrid.Controllers;
using GameGrid.GridObject;
using GameGrid.GridSpawners;
using UnityEngine;

namespace GameGrid
{
    [RequireComponent(typeof(CellGridSpawner),typeof(FruitGridSpawner),typeof(RockGridSpawner))]
    public class LevelGridCreator : MonoBehaviour, IInitGameSceneContext
    {
        [SerializeField] private CellGridSpawner _cellGridSpawner;
        [SerializeField] private FruitGridSpawner _fruitGridSpawner;
        
        public CellGridSpawner CellGridSpawner => _cellGridSpawner;
        public FruitGridSpawner FruitGridSpawner => _fruitGridSpawner;
        
        public void Init(GameSceneContext gameSceneContext)
        { 
            GridSettingData gridSettingData = gameSceneContext._gridSettingManager._gridSetting.GridSettingData;
            
            _cellGridSpawner.Spawn(gridSettingData);
            GridCell[,] cells = _cellGridSpawner.GetCells();
            _fruitGridSpawner.Spawn(cells, gridSettingData);
            
            GetComponent<RockGridSpawner>().Spawn(cells);
        }
    }
}