using UnityEngine;

public class PickUpObject : MonoBehaviour, IInteractable
{

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
        PlayerController playerController = PlayerComponentService<PlayerController>.instance;
        if (playerController.heldObject == null)
        {
            playerController.heldObject.transform.SetParent(PlayerComponentService<Transform>.instance);

            playerController.heldObject.transform.localPosition = new Vector2(playerController.pickedUpOffsetX, playerController.pickedUpOffsetY);
            playerController.heldObject.GetComponent<Collider2D>().enabled = false;
            playerController.heldObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            playerController.heldObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    public bool IsInteractable()
    {
        if (GameSession.Instance.actionBar.GetAction().GetType() == typeof(PickUp))
        {
            return true;
        }
        return false;
    }
}
