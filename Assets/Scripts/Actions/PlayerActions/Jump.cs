using UnityEngine;

public class Jump : IAction
{
    public bool HoldKeyDown { get { return false; } }
    public void Initiate() { }
    public void TriggerAction() 
    {
        PlayerController player = PlayerComponentService<PlayerController>.instance;

        if (player.isGrounded)
        {
            PlayerComponentService<Rigidbody2D>.instance.AddForce(PlayerComponentService<Transform>.instance.up * player.jumpForce);
            player.isGrounded = false;
        }
    }
}