using UnityEngine;

public class PickUp : IAction
{
    private PlayerController _player;
    
    public bool HoldKeyDown { get { return false; } }

    public void Initiate(PlayerController player)
    {
        _player = player;
    }

    public void TriggerAction()
    {
        if (_player.interactionController.ClosestInteractable != null &&
            _player.interactionController.ClosestInteractable.GetType() == typeof(PickUpObject) &&
            _player.heldObject != (PickUpObject)_player.interactionController.ClosestInteractable)
        {
            AudioManager.Instance.Play(_player.pickUpSound);
            PickUpObject pickUpObject = (PickUpObject)_player.interactionController.ClosestInteractable;
            PickUpObject(pickUpObject);
            _player.interactionController.ClosestInteractable.Interact(GameSession.player);
        }
        else
        {
            DropObject();
        }
    }

    public void AssignHeldObject(PickUpObject pickUpObject) => _player.heldObject = pickUpObject;


    private void PickUpObject(PickUpObject pickUpObject)
    {
        if (_player.heldObject != null)
        {
            DropObject();
        }
        if (_player.actionBar.ContainsAction<PickUp>())
        {
            Rigidbody2D rigidbody = pickUpObject.GetComponent<Rigidbody2D>();

            _player.heldObject = pickUpObject;
            _player.actionBar.GetAction();
            pickUpObject.transform.SetParent(_player.transform);
            pickUpObject.transform.localPosition = new Vector2(_player.pickedUpOffsetX, _player.pickedUpOffsetY);
            pickUpObject.transform.rotation = Quaternion.identity;

            pickUpObject.GetComponent<Collider2D>().enabled = false;
            rigidbody.freezeRotation = true;
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            rigidbody.velocity = new Vector2(0, 0);
        }
    }
    private void DropObject()
    {
        Collider2D heldObjectCollider = GameSession.player.heldObject?.GetComponent<Collider2D>();
        if (heldObjectCollider != null)
        {
            heldObjectCollider.transform.SetParent(null);
            heldObjectCollider.enabled = true;
            heldObjectCollider.attachedRigidbody.freezeRotation = false;
            heldObjectCollider.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
            heldObjectCollider.attachedRigidbody.AddForce(Vector2.right * (float)_player.FaceDirection * 200);

            GameSession.player.heldObject = null;
        }
    }
}
