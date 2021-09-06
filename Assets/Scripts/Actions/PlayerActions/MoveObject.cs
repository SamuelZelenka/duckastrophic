using UnityEngine;

public class MoveObject : IAction
{

    public void TriggerAction()
    {
        if(PlayerComponentService<InteractionController>.instance.ClosestInteractable.GetType() == typeof(PickUpObject))
        {
            PlayerComponentService<InteractionController>.instance.InteractWithClosestObject();
        }
    }

    public Sprite GetSprite() => SpriteReferences.Instance.DragObject;

}
