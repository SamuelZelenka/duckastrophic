using UnityEngine;

public class MoveObject : IAction
{

    public void TriggerAction(PlayerComponents playerComponents)
    {
        if(GameSession.Instance.playerComponents.InteractionController.ClosestInteractable.GetType() == typeof(PickUpObject))
        { 
        GameSession.Instance.playerComponents.InteractionController.InteractWithClosestObject();
        }
    }

    public Sprite GetSprite() => SpriteReferences.Instance.DragObject;

}
