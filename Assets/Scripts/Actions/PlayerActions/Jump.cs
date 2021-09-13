using UnityEngine;

public class Jump : IAction
{
    public bool HoldKeyDown { get { return false; } }

    public void Initiate() { }
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