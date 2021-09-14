using UnityEngine;

[RequireComponent(typeof(InteractableMarker))]
public abstract class SwapableObject : MonoBehaviour, IInteractable
{
    //clean up the variable order.
    public InteractableMarker Highlight { get; set; }
    public bool IsHighlighted { get; private set; }

    [SerializeField] private bool _JumpOnAwake = false;
    public Transform Transform => transform;

    protected virtual void Awake()
    {
        if (_JumpOnAwake) //Do we need this feature?
        {
            DroppedInteraction.ApplyDropForce(GetComponent<Rigidbody2D>());
        }
        Highlight = GetComponent<InteractableMarker>();
    }
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