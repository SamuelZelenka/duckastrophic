using UnityEngine;
public class MoveRight : IAction
{
    public void TriggerAction()
    {
        // G�r 11 till en variabel (const eller en max velocity) f�r att g�ra det tydligt vad 11 �r f�r n�got
        if (PlayerComponentService<Rigidbody2D>.instance.velocity.x < 11 )
        {
            PlayerComponentService<Rigidbody2D>.instance.AddForce(PlayerComponentService<PlayerController>.instance.transform.right * PlayerComponentService<PlayerController>.instance.movementSpeed);
            PlayerComponentService<SpriteRenderer>.instance.flipX = false;
        }
    }
    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.MoveRight;
    }
}