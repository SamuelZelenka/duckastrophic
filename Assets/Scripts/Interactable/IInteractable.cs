using UnityEngine;
public interface IInteractable
{
    Transform Transform { get; }

    InterractableMarker Highlight { get; set; }
    bool IsHighlighted { get; }

    public void Interact();
    public void EnableHighlight();
    public void DisableHighlight();
}
