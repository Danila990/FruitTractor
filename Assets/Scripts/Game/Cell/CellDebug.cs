#if UNITY_EDITOR
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Code
{
    public class CellDebug : MonoBehaviour
    {
        [SerializeField] private GridCreator _gridCreator;
        [SerializeField] CellType _needType;

        private Cell _cell;

        public void SetupGridCreator(GridCreator creator, CellType type = CellType.Empty)
        {
            _needType = type;
            _gridCreator = creator;
        }

        private void OnValidate()
        {
            _cell ??= GetComponent<Cell>();
            if (!gameObject.activeInHierarchy)
            {
                _needType = _cell._cellType;
            }
            if (_cell._cellType != _needType && gameObject.activeInHierarchy)
            {
                ChangeCell();
            }
        }

        public void ChangeCell()
        {
            _gridCreator.ChangeCell(_cell, _needType);
            UnityEditor.EditorApplication.delayCall += () =>
            {
                DestroyImmediate(gameObject);
            };
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