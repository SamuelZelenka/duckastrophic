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
        PlayerComponentService<InteractionController>.instance.OnClosestInteractableChange -= DisableHighlight;
        Highlight.ReleaseMarkers();
        IsHighlighted = false;
    }

    public void Interact()
    {
        if (PlayerComponentService<PlayerController>.instance.pickedUpObject != null)
        {
            PlayerComponentService<PlayerController>.instance.pickedUpObject = null;
            DroppedInteraction.ApplyDropForce(GetComponent<Rigidbody2D>());
        }

        PlayerComponentService<PlayerController>.instance.pickedUpObject = this;

        gameObject.transform.position = PlayerComponentService<Transform>.instance.position;
        gameObject.transform.position += new Vector3 (offsetX, offsetY, 0);
    }
}
