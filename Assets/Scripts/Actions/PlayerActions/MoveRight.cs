using UnityEngine;
public class MoveRight : IAction
{
    public void TriggerAction(PlayerComponents playerComponents)
    {
        // G�r 11 till en variabel (const eller en max velocity) f�r att g�ra det tydligt vad 11 �r f�r n�got
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