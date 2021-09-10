using UnityEngine;
public class MoveLeft : IAction
{
    public bool HoldKeyDown { get { return true; } }
    public void TriggerAction()
    {
        if (PlayerComponentService<Rigidbody2D>.instance.velocity.x < 11)
        {
            PlayerComponentService<Rigidbody2D>.instance.AddForce(PlayerComponentService<Transform>.instance.right * -PlayerComponentService<PlayerController>.instance.movementSpeed *  Time.deltaTime);
            PlayerComponentService<SpriteRenderer>.instance.flipX = true;
        }
    }
    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.MoveLeft;
    }
}

public class MoveRight : IAction
{
    public bool HoldKeyDown { get { return true; } }
    public void TriggerAction()
    {
        // Gör 11 till en variabel (const eller en max velocity) för att göra det tydligt vad 11 är för något
        if (PlayerComponentService<Rigidbody2D>.instance.velocity.x < 11)
        {
            PlayerComponentService<Rigidbody2D>.instance.AddForce(PlayerComponentService<PlayerController>.instance.transform.right * PlayerComponentService<PlayerController>.instance.movementSpeed * Time.deltaTime);
            PlayerComponentService<SpriteRenderer>.instance.flipX = false;
        }
    }
    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.MoveRight;
    }
}
