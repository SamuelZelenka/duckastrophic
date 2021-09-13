using UnityEngine;


public abstract class Dash : IAction
{
    public enum Direction {Left = -1, Right = 1 }

    public bool HoldKeyDown { get { return false; } }

    public abstract Sprite GetSprite();

    public virtual void Initiate() { }

    public abstract void TriggerAction();

    public virtual void DashDirection(Direction faceDirection)
    {
        PlayerController playerController = PlayerComponentService<PlayerController>.instance;
        Rigidbody2D rigidbody = PlayerComponentService<Rigidbody2D>.instance;

        if (playerController.lastDashTime + playerController.dashCooldown < Time.time)
        {
            rigidbody.velocity = new Vector2(-playerController.dashForce * (float)faceDirection, playerController.dashForce); ;
            playerController.lastDashTime = Time.time;
        }
    }
}

public class DashRight : Dash
{
    public override void TriggerAction() => DashDirection(Direction.Right);
    public override Sprite GetSprite() => SpriteReferences.Instance.DashRight;
}

public class DashLeft : Dash
{
    public override void TriggerAction() => DashDirection(Direction.Left);

    public override Sprite GetSprite() => SpriteReferences.Instance.DashLeft;
}
