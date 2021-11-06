using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NodeBuilder))]
public class NodeBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        NodeBuilder script = (NodeBuilder)target;
        if (GUILayout.Button("Build Nodes"))
        {
            script.BuildNodes();
        }
    }

    //public void OnSceneGUI()
    //{
    //    NodeBuilder script = target as NodeBuilder;

    //    if (script.nodes == null) return;

    //    for (int x = 0; x < script.maxSize; x++)
    //    {
    //        for (int y = 0; y < script.maxSize; y++)
    //        {
    //            if (script.nodes[x, y] != script.nullNode)
    //            {
    //                //Handles.Label(script.nodes[x, y], $"x: {x} y: {y}");
    //            }

    //        }
    //    }
    //}
}
