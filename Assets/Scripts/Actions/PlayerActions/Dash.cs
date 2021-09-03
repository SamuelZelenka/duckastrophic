using UnityEngine;

public class Dash : IAction
{
    public void TriggerAction(PlayerComponents playerComponents)
    {
        if (playerComponents.SpriteRenderer.flipX && playerComponents.Controller.lastDashTime + playerComponents.Controller.dashCooldown < Time.time)
        {
            playerComponents.RigidBody.velocity = new Vector2(playerComponents.Controller.dashForce, 0);
            playerComponents.Controller.lastDashTime = Time.time;
        }

        if (!playerComponents.SpriteRenderer.flipX && playerComponents.Controller.lastDashTime + playerComponents.Controller.dashCooldown < Time.time)
        {
            playerComponents.RigidBody.velocity = new Vector2(-playerComponents.Controller.dashForce, 0);
            playerComponents.Controller.lastDashTime = Time.time;
        }
    }

    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.Dash;
    }
}
