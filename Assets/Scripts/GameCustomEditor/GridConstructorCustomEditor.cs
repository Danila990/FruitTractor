#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GameCustomEditor
{
    [CustomEditor(typeof(GridConstructor))]
    public class GridConstructorCustomEditor : Editor
    {
        private GridConstructor _gridConstructor;
    
        private void OnEnable()
        {
            _gridConstructor = (GridConstructor)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Create new Grid/Setting", GUILayout.Height(30)))
            {
                _gridConstructor.CreateGridCells();
            }
            GUILayout.Space(2);
        
            if (GUILayout.Button("Save Current Grid Setting",GUILayout.Height(30)))
            {
                _gridConstructor.SaveCurrentGridSetting();
            }
            GUILayout.Space(2);
        
            if (GUILayout.Button("Load Grid To Create",GUILayout.Height(30)))
            {
                _gridConstructor.LoadGridToCreate();
            }
        }
    }
}

#endif

