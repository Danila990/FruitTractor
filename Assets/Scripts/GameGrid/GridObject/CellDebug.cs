#if UNITY_EDITOR
using Enums;
using UnityEngine;

namespace GameGrid.GridObject
{
    public class CellDebug : MonoBehaviour
    {
        [SerializeField] private GridCell _gridCell;
        

        private void OnDrawGizmos()
        {
            switch (_gridCell._typeCell)
            {
                case TypeCell.Empty:
                    Gizmos.color = Color.white;
                    break;
                case TypeCell.Space:
                    Gizmos.color = Color.black;
                    break;
                case TypeCell.Fruit:
                    Gizmos.color = Color.green;
                    break;
                case TypeCell.Rock:
                    Gizmos.color = Color.red;
                    break;
                case TypeCell.PlayerStart:
                    Gizmos.color = Color.blue;
                    break;
            }
            Gizmos.DrawCube(transform.position + Vector3.up * 0.3f,new Vector3(2,0.1f,2));

            if (_gridCell._typeCell != TypeCell.Fruit) return;
            
            switch (_gridCell._typeFruit)
            {
                case TypeFruit.Banana:
                    Gizmos.color = Color.yellow;
                    break;
                case TypeFruit.GreenApple:
                    Gizmos.color = Color.green;
                    break;
                case TypeFruit.Orange:
                    Gizmos.color = Color.blue;
                    break;
                case TypeFruit.Pear:
                    Gizmos.color = new Color(209,226,49);
                    break;
                case TypeFruit.Tomato:
                    Gizmos.color = Color.red;
                    break;
            }
            Gizmos.DrawSphere(transform.position + Vector3.up * 1f,0.4f);
        }
    }
}
#endif
