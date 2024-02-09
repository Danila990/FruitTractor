using System.Collections.Generic;
using Enums;
using GameGrid.GridObject;
using UnityEngine;

namespace GameGrid.GridSpawners
{
    public class FruitGridSpawner : MonoBehaviour
    {
        private const string FRUIT_PATH = "Prefabs/Fruit";
        
        [SerializeField] private float _fruitOffset;
        [SerializeField] private Transform _fruitParent;
        
        private Dictionary<Vector2Int, Fruit> _fruits = new Dictionary<Vector2Int, Fruit>();

        public void Spawn(GridCell[,] cells, GridSettingData gridSettingData)
        {
            Fruit[] gridFruits = LoadData();
            
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int z = 0; z < cells.GetLength(1); z++)
                {
                    if (cells[x,z]._typeCell != TypeCell.Fruit) continue;
                    
                    Fruit spawnFruit = Instantiate(GetFruitPrefab(gridFruits, gridSettingData.LineData[x].CellData[z].TypeFruit), _fruitParent);
                    spawnFruit.transform.position =
                        cells[x,z].gameObject.transform.position + new Vector3(0, _fruitOffset, 0);

                    _fruits.Add(cells[x, z]._gridIndex, spawnFruit);
                    spawnFruit.name = $"Fruit| X: {x} Y: {z}";
                }
            }
        }

        public Dictionary<Vector2Int, Fruit> GetFruits() => _fruits;

        private Fruit[] LoadData() => Resources.LoadAll<Fruit>(FRUIT_PATH);
        
        private Fruit GetFruitPrefab(Fruit[] gridFruits, TypeFruit needType)
        {
            foreach (Fruit fruit in gridFruits)
            {
                if (fruit._type == needType)
                    return fruit;
            }
            Debug.LogError("No need fruit type");
            return null;
        }
    }
}