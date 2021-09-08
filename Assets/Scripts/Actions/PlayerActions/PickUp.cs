using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : IAction
{
    public PickUpObject heldObject = null;
    public AudioClip duckQuack;
    public void DropObject()
    {
        Rigidbody2D rbody = heldObject.GetComponent<Rigidbody2D>();

        heldObject.transform.SetParent(null);

        heldObject.GetComponent<Collider2D>().enabled = true;
        rbody.bodyType = RigidbodyType2D.Dynamic;

        if (facingLeft)
        {
            rbody.AddForce(Vector2.left * 200);
        }
        else
        {
            rbody.AddForce(Vector2.right * 200);
        }

        heldObject = null;
    }

    public void TriggerAction()
    {
        AudioManager.Instance.Play(duckQuack);

        if (heldObject == null)
        {
            heldObject = pickUpObject;
            pickUpObject.transform.SetParent(transform);

            pickUpObject.transform.localPosition = new Vector2(_pickedUpOffsetX, _pickedUpOffsetY);
            pickUpObject.GetComponent<Collider2D>().enabled = false;
            pickUpObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            pickUpObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            DropObject();
        }
    }

    public Sprite GetSprite()
    {
        throw new System.NotImplementedException();
    }

    public void AssignHeldObject(PickUpObject pickUpObject)
    {
        heldObject = pickUpObject;
    }
}
