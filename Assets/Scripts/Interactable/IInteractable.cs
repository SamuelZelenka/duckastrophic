using UnityEngine;
public interface IInteractable
{
    Transform Transform { get; }
    public void Interact();
    public void EnableHighlight();
    public void DisableHighlight();
    public bool IsHighlighted();
}
