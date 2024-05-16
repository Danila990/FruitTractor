#if UNITY_EDITOR
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Code
{
    public class CellDebug : MonoBehaviour
    {
        [SerializeField] CellType _needType;

        public void SetupGridCreator(CellType type = CellType.Empty)
        {
            _needType = type;
        }

        private void OnValidate()
        {
            Cell cell = GetComponent<Cell>();
            if (!gameObject.activeInHierarchy)
            {
                _needType = cell._cellType;
            }
            else if(cell._cellType != _needType)
            {
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    if (cell._cellType != _needType && gameObject.activeInHierarchy)
                    {
                        ChangeCell();
                    }
                };
            }
        }

        public void ChangeCell()
        {
            GetComponentInParent<GridCreator>().ChangeCell(GetComponent<Cell>(), _needType);
            DestroyImmediate(gameObject);
        }
    }

    [CustomEditor(typeof(CellDebug))]
    public class CellDebugCustomEditor : Editor
    {
        private CellDebug _cellDebug;

        private void OnEnable()
        {
            _cellDebug = (CellDebug)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Update cell"))
            {
                _cellDebug.ChangeCell();
            }
        }
    }
}
#endif