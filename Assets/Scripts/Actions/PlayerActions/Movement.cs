using UnityEngine;

public abstract class Movement : IAction
{
    protected PlayerController player { get { return GameSession.player; } }

    public abstract bool HoldKeyDown { get; }
    public abstract void TriggerAction();

    public void Initiate(PlayerController player) { }
    protected virtual void MoveDirection(Direction direction)
    {
        float movementSpeed = player.acceleration;

        if (!player.isGrounded)
        {
            movementSpeed = 0.3f;
        }

        player.FaceDirection = direction;
        player.animator.SetBool("Running", true);
        player.rigidbody.velocity = player.rigidbody.velocity + Vector2.right * (float)direction * movementSpeed * Time.deltaTime;
    }
}

public class MoveLeft : Movement
{
    public override bool HoldKeyDown { get { return true; } }
    public override void TriggerAction()
    {
        if (player.rigidbody.velocity.x < player.maxVelocity)
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
        if (player.rigidbody.velocity.x < player.maxVelocity)
        {
            MoveDirection(Direction.Right);
        }
    }
}
