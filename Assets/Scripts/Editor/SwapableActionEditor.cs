using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SwapableAction)), CanEditMultipleObjects]
public class SwapableActionEditor : Editor
{
    private SerializedProperty _actionIndex;

    void OnEnable()
    {
        _actionIndex = serializedObject.FindProperty("actionIndex");
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        serializedObject.Update();

        List<string> options = new List<string>();
        SwapableAction target = (SwapableAction)this.target;
        for (int i = 0; i < target.actions.Length; i++)
        {
            options.Add(target.actions[i].ToString());
        }

        EditorGUI.BeginChangeCheck();
        _actionIndex.intValue = EditorGUILayout.Popup(_actionIndex.intValue, options.ToArray());
        EditorGUI.EndChangeCheck();
        serializedObject.ApplyModifiedProperties();
    }
}
