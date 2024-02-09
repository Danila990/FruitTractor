using Enums;
using GameGrid.GridObject;
using UnityEngine;

namespace GameGrid.GridSpawners
{
    public class RockGridSpawner : MonoBehaviour
    {
        private const string ROCK_PATH = "Prefabs/Rock";
        
        [SerializeField] private Transform _rockParent;
        
        public void Spawn(GridCell[,] cells)
        {
            GameObject[] rockPrefab = LoadPrefab();
            
            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLength(1); y++)
                {
                    if (cells[x,y]._typeCell != TypeCell.Rock) continue;
                    
                    GameObject spawnRock = Object.Instantiate(GetRandomRockPrefab(rockPrefab), _rockParent);
                    
                    spawnRock.transform.position = cells[x,y].gameObject.transform.position;
                    spawnRock.name = $"Rock| X: {x} Y: {y}";
                }
            }
        }
        
        private GameObject[] LoadPrefab() => Resources.LoadAll<GameObject>(ROCK_PATH);
        
        private GameObject GetRandomRockPrefab(GameObject[] rockPrefab) => rockPrefab[Random.Range(0, rockPrefab.Length)];
    }
}