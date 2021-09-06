using UnityEngine;

public class Dash : IAction
{
    public void TriggerAction()
    {
        if (PlayerComponentService<SpriteRenderer>.instance.flipX && PlayerComponentService<PlayerController>.instance.lastDashTime + PlayerComponentService<PlayerController>.instance.dashCooldown < Time.time)
        {
            PlayerComponentService<Rigidbody2D>.instance.velocity = new Vector2(PlayerComponentService<PlayerController>.instance.dashForce, 0);
            PlayerComponentService<PlayerController>.instance.lastDashTime = Time.time;
        }

        if (!PlayerComponentService<SpriteRenderer>.instance.flipX && PlayerComponentService<PlayerController>.instance.lastDashTime + PlayerComponentService<PlayerController>.instance.dashCooldown < Time.time)
        {
            PlayerComponentService<Rigidbody2D>.instance.velocity = new Vector2(-PlayerComponentService<PlayerController>.instance.dashForce, 0);
            PlayerComponentService<PlayerController>.instance.lastDashTime = Time.time;
        }
    }

    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.Dash;
    }
}
