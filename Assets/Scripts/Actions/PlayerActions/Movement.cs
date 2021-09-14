using UnityEngine;

public abstract class Movement : IAction
{
    public abstract bool HoldKeyDown { get; }
    public abstract Sprite GetSprite();
    public abstract void TriggerAction();

    public void Initiate() { }
    protected virtual void MoveDirection(Vector2 direction)
    {
        float movementSpeed = PlayerComponentService<PlayerController>.instance.movementSpeed; //add playerController variable for readability
        if (!PlayerComponentService<PlayerController>.instance.isGrounded) //Can we make this feel better somehow?!
        {
            movementSpeed *= 0.2f;
        }
        PlayerComponentService<Rigidbody2D>.instance.velocity = PlayerComponentService<Rigidbody2D>.instance.velocity + direction * movementSpeed * Time.deltaTime; //add rigidbody variable for readability
    }
}

public class MoveLeft : Movement
{
    public override bool HoldKeyDown { get { return true; } }
    public override void TriggerAction()
    {
        if (PlayerComponentService<Rigidbody2D>.instance.velocity.x < 11)
        {
            MoveDirection(-PlayerComponentService<Transform>.instance.right); //Change to Vector3.left for readability
            PlayerComponentService<PlayerController>.instance.IsFacingRight = false;
        }
    }
    public override Sprite GetSprite() //Make one line using lambda operator
    {
        return SpriteReferences.Instance.MoveLeft;
    }
}

public class MoveRight : Movement
{
    public override bool HoldKeyDown { get { return true; } }
    public override void TriggerAction()
    {
        // Gör 11 till en variabel (const eller en max velocity) för att göra det tydligt vad 11 är för något
        // gör en metod för move
        if (PlayerComponentService<Rigidbody2D>.instance.velocity.x < 11)
        {
            MoveDirection(PlayerComponentService<Transform>.instance.right); //Change to Vector3.right for readability
            PlayerComponentService<PlayerController>.instance.IsFacingRight = true;
        }
    }
    public override Sprite GetSprite() //Make one line using lambda operator
    {
        return SpriteReferences.Instance.MoveRight;
    }
}
