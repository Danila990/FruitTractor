using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class SpriteLoader
    {
        private Dictionary<string, Sprite> _spriteDictionary = new();

        public Sprite GetSprite(string assetPath)
        {
            if (_spriteDictionary.TryGetValue(assetPath, out Sprite dictionaryAsset))
                return dictionaryAsset;

            Sprite asset = Resources.Load(assetPath) as Sprite;
            if (asset == null)
                return null;

            _spriteDictionary.Add(assetPath, asset);
            return asset;
        }
    }
}