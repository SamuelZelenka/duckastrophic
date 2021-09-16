using UnityEngine;

[RequireComponent(typeof(InteractableMarker))]
public abstract class SwapableObject : MonoBehaviour, IInteractable
{
    public Transform Transform => transform;
    public bool IsHighlighted { get; private set; }
    public InteractableMarker Highlight { get; set; }

    protected PlayerController player;

    protected virtual void Awake() => Highlight = GetComponent<InteractableMarker>();

    public virtual void Interact(PlayerController player) => this.player = player;

    public void EnableHighlight()
    {
        Highlight.enabled = true;
        Highlight.GetMarkers();
        IsHighlighted = true;
    }
    public void DisableHighlight()
    {
        GameSession.player.interactionController.OnClosestInteractableChange -= DisableHighlight;
        Highlight.ReleaseMarkers();
        IsHighlighted = false;
    }

    public bool IsInteractable() => true;
}
