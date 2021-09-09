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
