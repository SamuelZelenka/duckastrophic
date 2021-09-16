using UnityEngine;
public interface IInteractable
{
    Transform Transform { get; }
    InteractableMarker Highlight { get; set; }
    bool IsHighlighted { get; }
    public bool IsInteractable();
    public void Interact(PlayerController player);
    public void EnableHighlight();
    public void DisableHighlight();
}
