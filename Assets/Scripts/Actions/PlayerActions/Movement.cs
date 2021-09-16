using UnityEngine;

public abstract class Movement : IAction
{
    protected PlayerController _player;

    public abstract bool HoldKeyDown { get; }
    public abstract void TriggerAction();

    public void Initiate(PlayerController player) => _player = player;
    protected virtual void MoveDirection(Direction direction)
    {
        float movementSpeed = _player.acceleration;

        if (!_player.isGrounded)
        {
            movementSpeed = 0.3f;
        }

        _player.FaceDirection = direction;
        _player.animator.SetBool("Running", true);
        _player.rigidbody.velocity = _player.rigidbody.velocity + Vector2.right * (float)direction * movementSpeed * Time.deltaTime;
    }
}

public class MoveLeft : Movement
{
    public override bool HoldKeyDown { get { return true; } }
    public override void TriggerAction()
    {
        if (_player.rigidbody.velocity.x < _player.maxVelocity)
        {
            MoveDirection(Direction.Left);
        }
    }
}

public class MoveRight : Movement
{
    public override bool HoldKeyDown { get { return true; } }
    public override void TriggerAction()
    {
        if (_player.rigidbody.velocity.x < _player.maxVelocity)
        {
            MoveDirection(Direction.Right);
        }
    }
}
