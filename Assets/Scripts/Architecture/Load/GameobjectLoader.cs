using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class GameobjectLoader
    {
        private Dictionary<string, GameObject> _gameobjectDictionary = new();

        public GameObject[] GetAll(string assetPath)
        {
            List<GameObject> gameObjects = new List<GameObject>();
            foreach (var dictionaryData in _gameobjectDictionary)
            {
                if(dictionaryData.Key == assetPath)
                {
                    gameObjects.Add(dictionaryData.Value);
                }
            }

            if(gameObjects.Count != 0)
            {
                return gameObjects.ToArray();
            }

            GameObject[] asset = Resources.LoadAll(assetPath) as GameObject[];
            if (asset == null)
            {
                return null;
            }

            foreach (var item in asset)
            {
                item.SetActive(false);
                _gameobjectDictionary.Add(assetPath, item);
            }

            return asset;
        }

        public T[] GetAll<T>(string assetPath) where T : MonoBehaviour
        {
            return GetAll(assetPath) as T[];
        }

        public GameObject Get(string assetPath)
        {
            if (_gameobjectDictionary.TryGetValue(assetPath, out GameObject dictionaryAsset))
            {
                return dictionaryAsset;
            } 

            GameObject asset = Resources.Load(assetPath) as GameObject;
            if (asset == null)
            {
               return null;
            }

            asset.SetActive(false);
            _gameobjectDictionary.Add(assetPath, asset);
            return asset;
        }

        public T Get<T>(string assetPath) where T : MonoBehaviour
        {
            return Get(assetPath) as T;
        }
    }
}