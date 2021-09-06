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
        PlayerComponentService<InteractionController>.instance.OnClosestInteractableChange -= DisableHighlight;
        Highlight.ReleaseMarkers();
        IsHighlighted = false;
    }

    public void Interact()
    {
        PlayerComponentService<PlayerController>.instance.PickUpObject(this);
    }
}
