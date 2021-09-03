using UnityEngine;

public class Jump : IAction
{
    public void TriggerAction(PlayerComponents playerComponents)
    {
        if (playerComponents.Controller.isGrounded)
        {
            playerComponents.RigidBody.AddForce(playerComponents.Transform.up * playerComponents.Controller.jumpForce);
            playerComponents.Controller.isGrounded = false;
        }
    }
    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.Jump;
    }
}