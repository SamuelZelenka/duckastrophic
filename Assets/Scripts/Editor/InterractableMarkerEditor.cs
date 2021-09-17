using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(InteractableMarker))]
public class InteractableMarkerEditor : Editor
{
    InteractableMarker _marker;
    void OnEnable() => _marker = this.target as InteractableMarker;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (_marker.GetComponent<Collider2D>() == null)
        {
            EditorGUILayout.HelpBox("Collider2D is missing", MessageType.Error);
        }
        if (_marker.GetComponent<IInteractable>() == null)
        {
            EditorGUILayout.HelpBox("Interactable component is missing", MessageType.Error);
        }

    }
}
