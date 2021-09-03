using UnityEngine;
public interface IInteractable
{
    Transform Transform { get; }

    InteractableMarker Highlight { get; set; }
    bool IsHighlighted { get; }

    public void Interact();
    public void EnableHighlight();
    public void DisableHighlight();
}
