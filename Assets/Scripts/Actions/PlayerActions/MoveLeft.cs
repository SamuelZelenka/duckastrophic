using UnityEngine;
public class MoveLeft : IAction
{
    public void TriggerAction(PlayerComponents playerComponents)
    {
        if (playerComponents.RigidBody.velocity.x < 11)
        {
            playerComponents.RigidBody.AddForce(playerComponents.Transform.right * -playerComponents.Controller.movementSpeed);
            playerComponents.SpriteRenderer.flipX = true;
        }
    }
    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.MoveLeft;
    }
}
