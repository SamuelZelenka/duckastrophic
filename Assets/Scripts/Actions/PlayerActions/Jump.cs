using UnityEngine;
public class Jump : IAction
{

    protected PlayerController _player;
    public bool HoldKeyDown { get { return false; } }
    public void Initiate(PlayerController player) 
    {
        _player = player;
    }
    public void TriggerAction() 
    {
        if (_player.isGrounded)
        {
            _player.rigidbody.velocity = new Vector2(_player.rigidbody.velocity.x , _player.jumpForce) ;
        }
    }
}