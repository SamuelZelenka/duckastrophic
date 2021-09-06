using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InteractableMarker))]
public class InteractableMarkerEditor : Editor
{
    InteractableMarker marker;
    void OnEnable()
    {
        marker = this.target as InteractableMarker;
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (marker.GetComponent<Collider2D>() == null)
        {
            EditorGUILayout.HelpBox("Collider2D is missing", MessageType.Error);
        }
        if (marker.GetComponent<IInteractable>() == null)
        {
            EditorGUILayout.HelpBox("Interactable component is missing", MessageType.Error);
        }

    }
}
