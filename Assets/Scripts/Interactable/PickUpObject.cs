using UnityEngine;

public class PickUpObject : MonoBehaviour, IInteractable
{
    public InteractableMarker Highlight { get; set; }
    public bool IsHighlighted { get; private set; }

    public Transform Transform => transform;

    public void EnableHighlight()
    {
        Highlight.enabled = true;
        Highlight.GetMarkers();
        IsHighlighted = true;
    }
    public void DisableHighlight()
    {
        GameSession.Instance.playerComponents.InteractionController.OnClosestInteractableChange -= DisableHighlight;
        Highlight.ReleaseMarkers();
        IsHighlighted = false;
    }

    public void Interact()
    {
        GameSession.Instance.playerComponents.Controller.PickUpObject(this);
    }
}
