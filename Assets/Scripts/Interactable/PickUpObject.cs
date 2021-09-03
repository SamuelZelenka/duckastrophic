using UnityEngine;

public class PickUpObject : MonoBehaviour, IInteractable
{
    public int offsetY = 1;
    public int offsetX = 0;

    [SerializeField] private InterractableMarker _highlight;
    [SerializeField] private bool _isHighlighted;


    public Transform Transform => transform;

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
    public bool IsHighlighted()
    {
        return _isHighlighted;
    }

    public void Interact()
    {
        if (GameSession.Instance.playerComponents.Controller.pickedUpObject != null)
        {
            GameSession.Instance.playerComponents.Controller.pickedUpObject = null;
            DroppedInteraction.ApplyDropForce(GetComponent<Rigidbody2D>());
        }

        GameSession.Instance.playerComponents.Controller.pickedUpObject = this;

        gameObject.transform.position = GameSession.Instance.playerComponents.Transform.position;
        gameObject.transform.position += new Vector3 (offsetX, offsetY, 0);
    }
}
