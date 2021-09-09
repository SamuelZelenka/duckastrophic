using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : IAction
{

    public AudioClip duckQuack;

    public bool HoldKeyDown { get { return false; } }

    private PlayerController _playerController;

    public PickUp()
    {
        _playerController = PlayerComponentService<PlayerController>.instance;
    }

    public void TriggerAction()
    {
        AudioManager.Instance.Play(duckQuack);
        if (PlayerComponentService<InteractionController>.instance.ClosestInteractable != null && PlayerComponentService<InteractionController>.instance.ClosestInteractable.GetType() == typeof(PickUpObject))
        {
            PlayerComponentService<InteractionController>.instance.ClosestInteractable.Interact();
        }
        else
        {
            PlayerComponentService<PlayerController>.instance.heldObject?.Interact();
        }
    }

    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.PickUpObject;
    }

    public void AssignHeldObject(PickUpObject pickUpObject)
    {
        PlayerComponentService<PlayerController>.instance.heldObject = pickUpObject;
    }
}
