using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MapBuilder))]
public class MapBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapBuilder script = (MapBuilder)target;
        if (GUILayout.Button("Build Map"))
        {
            script.BuildMap();
        }
    }
}
