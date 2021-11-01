using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HelloScript))]
public class HelloScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        HelloScript script = (HelloScript)target;
        if (GUILayout.Button("Build Nodes"))
        {
            script.BuildNodes();
        }
    }
}
