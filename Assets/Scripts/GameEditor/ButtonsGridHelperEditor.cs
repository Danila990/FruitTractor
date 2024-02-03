#if UNITY_EDITOR

using GameEditor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridHelper))]
public class ButtonsGridHelperEditor : Editor
{
    private GridHelper _gridHelper;
    
    private void OnEnable()
    {
        _gridHelper = (GridHelper)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Create new Grid/Setting", GUILayout.Height(30)))
        {
            _gridHelper.CreateGridCells();
        }
        GUILayout.Space(2);
        
        if (GUILayout.Button("Save Current Grid Setting",GUILayout.Height(30)))
        {
            _gridHelper.SaveCurrentGridSetting();
        }
        GUILayout.Space(2);
        
        if (GUILayout.Button("Load Grid To Create",GUILayout.Height(30)))
        {
            _gridHelper.LoadGridToCreate();
        }
        GUILayout.Space(2);
        
        if (GUILayout.Button("Dublicate Current Grid Setting",GUILayout.Height(30)))
        {
            _gridHelper.DublicateCurrentGrid();
        }
    }
}

#endif

