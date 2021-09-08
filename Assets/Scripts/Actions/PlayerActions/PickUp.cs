using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : IAction
{

    public AudioClip duckQuack;

    private PlayerController _playerController;

    public PickUp()
    {
        _playerController = PlayerComponentService<PlayerController>.instance;
    }

    public void DropObject()
    {
        Rigidbody2D rbody = _playerController.heldObject.GetComponent<Rigidbody2D>();

        _playerController.heldObject.transform.SetParent(null);

        _playerController.heldObject.GetComponent<Collider2D>().enabled = true;
        rbody.bodyType = RigidbodyType2D.Dynamic;

        if (_playerController.isFacingRight)
        {
            rbody.AddForce(Vector2.left * 200);
        }
        else
        {
            rbody.AddForce(Vector2.right * 200);
        }

        _playerController.heldObject = null;
    }

    public void TriggerAction()
    {
        AudioManager.Instance.Play(duckQuack);

    }

    public Sprite GetSprite()
    {
        return null;
    }

    public void AssignHeldObject(PickUpObject pickUpObject)
    {
        PlayerComponentService<PlayerController>.instance.heldObject = pickUpObject;
    }
}
