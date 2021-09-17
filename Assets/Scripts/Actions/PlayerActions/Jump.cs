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
            _player.rigidbody.AddForce(_player.transform.up * _player.jumpForce);
            _player.isGrounded = false;
        }
    }
}