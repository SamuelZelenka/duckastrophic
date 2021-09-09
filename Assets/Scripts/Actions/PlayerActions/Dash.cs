using UnityEngine;

public class DashRight : IAction
{
    public bool HoldKeyDown { get { return false; } }
    public void TriggerAction()
    {
        PlayerController playerController = PlayerComponentService<PlayerController>.instance;
        Rigidbody2D rigidbody = PlayerComponentService<Rigidbody2D>.instance;

        // dash right
        if (playerController.lastDashTime + playerController.dashCooldown < Time.time)
        {
            rigidbody.velocity = new Vector2(playerController.dashForce, playerController.dashForce);
            playerController.lastDashTime = Time.time;
        }
    }

    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.DashRight;
    }
}

public class DashLeft : IAction
{
    public bool HoldKeyDown { get { return false; } }
    public void TriggerAction()
    {
        PlayerController playerController = PlayerComponentService<PlayerController>.instance;
        Rigidbody2D rigidbody = PlayerComponentService<Rigidbody2D>.instance;

        // dash left
        if (playerController.lastDashTime + playerController.dashCooldown < Time.time)
        {
            rigidbody.velocity = new Vector2(-playerController.dashForce, playerController.dashForce);
            playerController.lastDashTime = Time.time;
        }
    }

    public Sprite GetSprite()
    {
        return SpriteReferences.Instance.DashLeft;
    }
}
