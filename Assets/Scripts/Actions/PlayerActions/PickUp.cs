using System.Collections;
using System.Collections.Generic; //Remove unused namespaces
using UnityEngine;

public class PickUp : IAction
{
    //Sort variables public , [serializedfield], private
    public AudioClip duckQuack; // Make an Audio library to hold audioclips? Variable name can be improved on what kind of variable it is. 

    private PlayerController _playerController;
    private InteractionController _interactionController;
    
    public bool HoldKeyDown { get { return false; } }

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
        }
        else
        {
            DropObject();
        }
    }

    public void AssignHeldObject(PickUpObject pickUpObject) => _playerController.heldObject = pickUpObject;


    private void PickUpObject(PickUpObject pickUpObject)
    {
        if (_playerController.heldObject != null)
        {
            DropObject();
        }
        if (_playerController.actionBar.ContainsAction<PickUp>())
        {
            Rigidbody2D rigidbody = pickUpObject.GetComponent<Rigidbody2D>();

            _playerController.heldObject = pickUpObject;
            _playerController.actionBar.GetAction();
            pickUpObject.transform.SetParent(_playerController.transform);
            pickUpObject.transform.localPosition = new Vector2(_playerController.pickedUpOffsetX, _playerController.pickedUpOffsetY);
            pickUpObject.transform.rotation = Quaternion.identity;

            pickUpObject.GetComponent<Collider2D>().enabled = false;
            rigidbody.freezeRotation = true;
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
            rigidbody.velocity = new Vector2(0, 0);
        }
    }

    private void DropObject()
    {
        Collider2D heldObjectCollider = _playerController.heldObject.GetComponent<Collider2D>();
        _playerController.heldObject.transform.SetParent(null);
        heldObjectCollider.enabled = true;
        heldObjectCollider.attachedRigidbody.freezeRotation = false;
        heldObjectCollider.attachedRigidbody.bodyType = RigidbodyType2D.Dynamic;
        heldObjectCollider.attachedRigidbody.AddForce(Vector2.right * (float)_playerController.FaceDirection * 200);

        _playerController.heldObject = null;
    }
}
