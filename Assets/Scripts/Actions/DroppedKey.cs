using UnityEngine;

[RequireComponent(typeof(InterractableMarker))]
public abstract class DroppedKey : MonoBehaviour, IInteractable
{
    [SerializeField] private InterractableMarker _highlight;
    [SerializeField] private bool _isHighlighted;
    [SerializeField] private bool _JumpOnAwake = false;
    public Transform Transform => transform;

    protected virtual void Awake()
    {
        if (_JumpOnAwake)
        {
            DroppedInteraction.ApplyDropForce(GetComponent<Rigidbody2D>());
        }
        _highlight = GetComponent<InterractableMarker>();
    }
    public abstract void Interact();

    public void EnableHighlight()
    {
        _highlight.enabled = true;
        _highlight.GetMarkers();
        _isHighlighted = true;
    }
    public void DisableHighlight()
    {
        GameSession.Instance.playerComponents.InteractionController.OnClosestInteractableChange -= DisableHighlight;
        _highlight.ReleaseMarkers();
        _isHighlighted = false;
    }
    public bool IsHighlighted() => _isHighlighted;
}
