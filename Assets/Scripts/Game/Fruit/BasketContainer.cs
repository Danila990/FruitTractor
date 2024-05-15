using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "BasketContainer", menuName = "BasketContainer")]
    public class BasketContainer : ScriptableObject
    {
        [SerializeField] private List<BasketButtonData> _basketDatas = new List<BasketButtonData>();
        [field: SerializeField] public BasketButton _basketButtonPrefab { get; private set; }

        public BasketButtonData GetBasketData(FruitType needFruitType)
        {
            return _basketDatas.FirstOrDefault(data => data._fruitType == needFruitType);
        }
    }

    [Serializable]
    public class BasketButtonData
    {
        [field: SerializeField] public FruitType _fruitType { get; private set; }
        [field: SerializeField] public Sprite _fruitIcon { get; private set; }
    }
}