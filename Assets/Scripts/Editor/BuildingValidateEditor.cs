using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingValidate))]
public class BuildingManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BuildingValidate script = (BuildingValidate)target;

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button(new GUIContent("Fixed")))
            script.SetMaterial(PlacementMode.Fixed);
        if (GUILayout.Button(new GUIContent("Valid")))
            script.SetMaterial(PlacementMode.Valid);
        if (GUILayout.Button(new GUIContent("Invalid")))
            script.SetMaterial(PlacementMode.Invalid);
        EditorGUILayout.EndHorizontal();
    }
}

