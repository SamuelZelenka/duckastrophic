using UnityEngine;
public class MoveLeft : IAction
{
    public void TriggerAction()
    {
        if (PlayerComponentService<Rigidbody2D>.instance.velocity.x < 11)
        {
            PlayerComponentService<Rigidbody2D>.instance.AddForce(PlayerComponentService<Transform>.instance.right * -PlayerComponentService<PlayerController>.instance.movementSpeed);
            PlayerComponentService<Transform>.instance.localScale = new Vector3(-1,1,1);
        }
    }
    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.MoveLeft;
    }
}
