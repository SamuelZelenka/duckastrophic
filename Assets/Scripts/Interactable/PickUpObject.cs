using UnityEngine;
[SelectionBase]
[RequireComponent(typeof(InteractableMarker))]
public class PickUpObject : MonoBehaviour, IInteractable
{
    //Sort variables
    public InteractableMarker Highlight { get; set; }
    public bool IsHighlighted { get; private set; }

    public Transform Transform => transform;

    private void Awake() //lambda stuff
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

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

    public void Interact() { }

    public bool IsInteractable() => PlayerComponentService<PlayerController>.instance.actionBar.ContainsAction<PickUp>();
}
