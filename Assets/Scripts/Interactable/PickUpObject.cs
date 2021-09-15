using UnityEngine;
[SelectionBase]
[RequireComponent(typeof(InteractableMarker))]
public class PickUpObject : MonoBehaviour, IInteractable
{
    public bool IsHighlighted { get; private set; }
    public Transform Transform  { get { return transform; } }
    public InteractableMarker Highlight { get; set; }


    private void Awake() => gameObject.layer = LayerMask.NameToLayer("Interactable");

    public void EnableHighlight()
    {
        Highlight.enabled = true;
        Highlight.GetMarkers();
        IsHighlighted = true;
    }
    public void DisableHighlight()
    {
        PlayerController player = PlayerComponentService<PlayerController>.instance;

        player.interactionController.OnClosestInteractableChange -= DisableHighlight;
        Highlight.ReleaseMarkers();
        IsHighlighted = false;
    }

    public void Interact() { }

    public bool IsInteractable()
    {
        PlayerController player = PlayerComponentService<PlayerController>.instance;
        return player.actionBar.ContainsAction<PickUp>();
    }
}
