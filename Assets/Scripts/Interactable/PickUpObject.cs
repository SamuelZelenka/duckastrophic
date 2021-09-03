using UnityEngine;

public class PickUpObject : MonoBehaviour, IInteractable
{
    public int offsetY = 1;
    public int offsetX = 0;

    public InteractableMarker Highlight { get; set; }
    public bool IsHighlighted { get; private set; }


    public Transform Transform => transform;

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
