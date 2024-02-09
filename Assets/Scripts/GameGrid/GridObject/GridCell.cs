using Enums;
using UnityEngine;

namespace GameGrid.GridObject
{
    public class GridCell : MonoBehaviour
    {
        [SerializeField] private GameObject _cellMesh;
        [SerializeField] private Renderer _rendererModel;
        
        [field: SerializeField] public TypeCell _typeCell { get; private set; }
        
        public Vector2Int _gridIndex { get; private set; }

        public void Init(TypeCell type, Vector2Int gridIndex)
        {
            _typeCell = type;
            _gridIndex = gridIndex;
            ChangeColor();
        }

        public void Init(TypeCell type)
        {
            _typeCell = type;
            ChangeColor();
        }

        private void ChangeColor()
        {
            switch (_typeCell)
            {
                case TypeCell.Empty:
                    _rendererModel.material.color = Color.white;
                    break;
                case TypeCell.Space:
                    _cellMesh.SetActive(false);
                    break;
                case TypeCell.Fruit:
                    _rendererModel.material.color = Color.green;
                    break;
                case TypeCell.Rock:
                    _rendererModel.material.color = Color.red;
                    break;
                case TypeCell.PlayerStart:
                    _rendererModel.material.color = Color.blue;
                    break;
            }
        }
        

#if UNITY_EDITOR
        [field: SerializeField] public TypeFruit _typeFruit { get; private set; }
        
        public void Init(TypeCell type, TypeFruit typeFruit)
        {
            _typeCell = type;
            _typeFruit = typeFruit;
        }
#endif
    }
}