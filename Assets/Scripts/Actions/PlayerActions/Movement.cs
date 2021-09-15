using UnityEngine;

public abstract class Movement : IAction
{
    public PlayerController player = PlayerComponentService<PlayerController>.instance;
    public Rigidbody2D rigidbody = PlayerComponentService<Rigidbody2D>.instance;

    public abstract bool HoldKeyDown { get; }
    public abstract void TriggerAction();

    public void Initiate() { }
    protected virtual void MoveDirection(Direction direction)
    {
        float movementSpeed = player.acceleration;

        if (!player.isGrounded)
        {
            movementSpeed = 0.3f;
        }

        player.FaceDirection = direction; 
        PlayerComponentService<Animator>.instance.SetBool("Running", true);
        rigidbody.velocity = rigidbody.velocity + Vector2.right * (float)direction * movementSpeed * Time.deltaTime;
    }
}

public class MoveLeft : Movement
{
    public override bool HoldKeyDown { get { return true; } }
    public override void TriggerAction()
    {
        if (rigidbody.velocity.x < player.maxVelocity)
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
        if (rigidbody.velocity.x < player.maxVelocity)
        {
            MoveDirection(Direction.Right);
        }
    }
}
