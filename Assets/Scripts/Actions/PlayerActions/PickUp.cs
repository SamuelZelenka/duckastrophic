using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : IAction
{

    private Rigidbody2D _rigidBody;

    public AudioClip duckQuack;

    public bool HoldKeyDown { get { return false; } }

    private PlayerController _playerController;
    private InteractionController _interactionController;

    public void Initiate()
    {
        _playerController = PlayerComponentService<PlayerController>.instance;
        _interactionController = _playerController.interactionController;
    }

    public void TriggerAction()
    {
        AudioManager.Instance.Play(duckQuack);
        if (_interactionController.ClosestInteractable != null &&
            _interactionController.ClosestInteractable.GetType() == typeof(PickUpObject))
        {
            PickUpObject pickUpObject = (PickUpObject)_interactionController.ClosestInteractable;
            PickUpObject(pickUpObject);
            _interactionController.ClosestInteractable.Interact();
            _rigidBody = pickUpObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            _playerController.heldObject?.Interact();
        }
    }

    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.PickUpObject;
    }

    public void AssignHeldObject(PickUpObject pickUpObject)
    {
        _playerController.heldObject = pickUpObject;
    }

    private void PickUpObject(PickUpObject pickUpObject)
    {
        if (_playerController.heldObject != null)
        {
            DropObject();
        }
        if (PlayerComponentService<PlayerController>.instance.actionBar.ContainsAction<PickUp>())
        {
            _playerController.heldObject = pickUpObject;
            PlayerComponentService<PlayerController>.instance.actionBar.GetAction();
            pickUpObject.transform.SetParent(_playerController.transform);
            pickUpObject.transform.localPosition = new Vector2(_playerController.pickedUpOffsetX, _playerController.pickedUpOffsetY);
            pickUpObject.transform.rotation = Quaternion.identity;

            pickUpObject.GetComponent<Collider2D>().enabled = false;
            _rigidBody.freezeRotation = true;
            _rigidBody.bodyType = RigidbodyType2D.Kinematic;
            _rigidBody.velocity = new Vector2(0, 0);
        }
    }
    private void DropObject()
    {
        Collider2D heldObjectCollider = _playerController.heldObject.GetComponent<Collider2D>();
        _playerController.heldObject.transform.SetParent(null);
        heldObjectCollider.enabled = true;
        heldObjectCollider.attachedRigidbody.freezeRotation = false;
        heldObjectCollider.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;

        if (_playerController.IsFacingRight)
        {
            heldObjectCollider.attachedRigidbody.AddForce(Vector2.right * 200);
        }
        else
        {
            heldObjectCollider.attachedRigidbody.AddForce(Vector2.left * 200);
        }

       _playerController.heldObject = null;
    }

}
