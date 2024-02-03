using System;
using Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Grid
{
    public class Cell : MonoBehaviour
    {
        [field: SerializeField] public TypeCell Type { get; private set; }
        
        public void Init(TypeCell type)
        {
            Type = type;
        }

#if UNITY_EDITOR
        
        private void OnDrawGizmos()
        {
            switch (Type)
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
            
            Gizmos.DrawCube(transform.position,new Vector3(1,0.1f,1));
        }
#endif
    }
}
