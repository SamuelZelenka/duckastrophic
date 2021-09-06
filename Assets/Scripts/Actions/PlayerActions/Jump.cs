using UnityEngine;

public class Jump : IAction
{
    public void TriggerAction()
    {
        if (PlayerComponentService<PlayerController>.instance.isGrounded)
        {
            PlayerComponentService<Rigidbody2D>.instance.AddForce(PlayerComponentService<Transform>.instance.up * PlayerComponentService<PlayerController>.instance.jumpForce);
            PlayerComponentService<PlayerController>.instance.isGrounded = false;
        }
    }
    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.Jump;
    }
}