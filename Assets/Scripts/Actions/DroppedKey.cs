using UnityEngine;

[RequireComponent(typeof(InterractableMarker))]
public abstract class DroppedKey : MonoBehaviour, IInteractable
{
    public InterractableMarker Highlight { get; set; }
    public bool IsHighlighted { get; private set; }

    [SerializeField] private bool _JumpOnAwake = false;
    public Transform Transform => transform;

    protected virtual void Awake()
    {
        if (_JumpOnAwake)
        {
            DroppedInteraction.ApplyDropForce(GetComponent<Rigidbody2D>());
        }
        Highlight = GetComponent<InterractableMarker>();
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
        GameSession.Instance.playerComponents.InteractionController.OnClosestInteractableChange -= DisableHighlight;
        Highlight.ReleaseMarkers();
        IsHighlighted = false;
    }
}
