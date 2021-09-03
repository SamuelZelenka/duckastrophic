using UnityEngine;
public class MoveRight : IAction
{
    public void TriggerAction(PlayerComponents playerComponents)
    {
        // Gör 11 till en variabel (const eller en max velocity) för att göra det tydligt vad 11 är för något
        if (playerComponents.RigidBody.velocity.x < 11 )
        {
            playerComponents.RigidBody.AddForce(playerComponents.Controller.transform.right * playerComponents.Controller.movementSpeed);
            playerComponents.SpriteRenderer.flipX = false;
        }
    }
    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.MoveRight;
    }
}