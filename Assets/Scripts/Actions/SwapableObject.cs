using UnityEngine;

[RequireComponent(typeof(InteractableMarker))]
public abstract class SwapableObject : MonoBehaviour, IInteractable
{
    public Transform Transform => transform;
    public bool IsHighlighted { get; private set; }
    public InteractableMarker Highlight { get; set; }

    protected virtual void Awake() => Highlight = GetComponent<InteractableMarker>();

    public abstract void Interact();

    public void EnableHighlight()
    {
        Highlight.enabled = true;
        Highlight.GetMarkers();
        IsHighlighted = true;
    }
    public void DisableHighlight()
    {
        PlayerComponentService<PlayerController>.instance.interactionController.OnClosestInteractableChange -= DisableHighlight;
        Highlight.ReleaseMarkers();
        IsHighlighted = false;
    }

    public bool IsInteractable() => true;
}
