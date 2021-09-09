using UnityEngine;

public class PickUpObject : MonoBehaviour, IInteractable
{
    public InteractableMarker Highlight { get; set; }
    public bool IsHighlighted { get; private set; }

    public Transform Transform => transform;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

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
            PickUp(playerController);
        }
        else
        {
            DropObject();
        }
    }

    private void PickUp(PlayerController playerController)
    {
        if (GameSession.Instance.actionBar.ContainsAction<PickUp>())
        {
            playerController.heldObject = this;
            GameSession.Instance.actionBar.GetAction();
            transform.SetParent(playerController.transform);
            transform.localPosition = new Vector2(playerController.pickedUpOffsetX, playerController.pickedUpOffsetY);
            transform.rotation = Quaternion.identity;

            GetComponent<Collider2D>().enabled = false;
            _rigidBody.freezeRotation = true;
            _rigidBody.bodyType = RigidbodyType2D.Kinematic;
            _rigidBody.velocity = new Vector2(0, 0);
        }
    }
    private void DropObject()
    {
        transform.SetParent(null);

        GetComponent<Collider2D>().enabled = true;
        _rigidBody.freezeRotation = false;
        _rigidBody.bodyType = RigidbodyType2D.Dynamic;

        if (PlayerComponentService<PlayerController>.instance.isFacingRight)
        {
            _rigidBody.AddForce(Vector2.right * 200);
        }
        else
        {
            _rigidBody.AddForce(Vector2.left * 200);
        }

        PlayerComponentService<PlayerController>.instance.heldObject = null;
    }

    public bool IsInteractable() => GameSession.Instance.actionBar.ContainsAction<PickUp>();
}
