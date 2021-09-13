using UnityEngine;

public abstract class Movement : IAction
{
    public abstract bool HoldKeyDown { get; }

    public abstract Sprite GetSprite();

    public abstract void TriggerAction();

    public void Initiate() { }
    protected virtual void MoveDirection(Vector2 direction)
    {
        float movementSpeed = PlayerComponentService<PlayerController>.instance.movementSpeed;
        if (!PlayerComponentService<PlayerController>.instance.isGrounded)
        {
            movementSpeed *= 0.2f;
        }
        PlayerComponentService<Rigidbody2D>.instance.velocity = PlayerComponentService<Rigidbody2D>.instance.velocity + direction * movementSpeed * Time.deltaTime;
    }
}

public class MoveLeft : Movement
{
    public override bool HoldKeyDown { get { return true; } }
    public override void TriggerAction()
    {
        if (PlayerComponentService<Rigidbody2D>.instance.velocity.x < 11)
        {
            MoveDirection(-PlayerComponentService<Transform>.instance.right);
            PlayerComponentService<PlayerController>.instance.IsFacingRight = false;
        }
    }
    public override Sprite GetSprite()
    {
        return SpriteReferences.Instance.MoveLeft;
    }
}

public class MoveRight : Movement
{
    public override bool HoldKeyDown { get { return true; } }
    public override void TriggerAction()
    {
        // G�r 11 till en variabel (const eller en max velocity) f�r att g�ra det tydligt vad 11 �r f�r n�got
        // g�r en metod f�r move
        if (PlayerComponentService<Rigidbody2D>.instance.velocity.x < 11)
        {
            MoveDirection(PlayerComponentService<Transform>.instance.right);
            PlayerComponentService<PlayerController>.instance.IsFacingRight = true;
        }
    }
    public override Sprite GetSprite()
    {
        return SpriteReferences.Instance.MoveRight;
    }
}
