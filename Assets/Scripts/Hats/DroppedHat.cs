using System;
using UnityEngine;

public class DroppedHat : DroppedObject, IInteractable
{
    [SerializeField] private Sprite hatSprite;
    public override void Interact()
    {
    }
}
