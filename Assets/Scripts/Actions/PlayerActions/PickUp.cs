using System.Collections;
using System.Collections.Generic; //Remove unused namespaces
using UnityEngine;

public class PickUp : IAction
{
    //Sort variables public , [serializedfield], private
    private Rigidbody2D _rigidbody; // Is the Action responsible for the Rigidbody?

    public AudioClip duckQuack; // Make an Audio library to hold audioclips? Variable name can be improved on what kind of variable it is. 

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
            _rigidbody = pickUpObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            DropObject();
        }
    }

    public void AssignHeldObject(PickUpObject pickUpObject) //Make one line using lambda operator
    {
        _playerController.heldObject = pickUpObject;
    }

    private void PickUpObject(PickUpObject pickUpObject)
    {
        if (_playerController.heldObject != null)
        {
            DropObject();
        }
        if (PlayerComponentService<PlayerController>.instance.actionBar.ContainsAction<PickUp>()) //Create Actionbar as a variable as it is used twice. For readability
        {
            _playerController.heldObject = pickUpObject;
            PlayerComponentService<PlayerController>.instance.actionBar.GetAction();
            pickUpObject.transform.SetParent(_playerController.transform);
            pickUpObject.transform.localPosition = new Vector2(_playerController.pickedUpOffsetX, _playerController.pickedUpOffsetY);
            pickUpObject.transform.rotation = Quaternion.identity;

            pickUpObject.GetComponent<Collider2D>().enabled = false;
            pickUpObject.GetComponent<Rigidbody2D>().freezeRotation = true;
            pickUpObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            pickUpObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
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
