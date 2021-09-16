using UnityEngine;

public abstract class Dash : IAction
{
    protected PlayerController player;
    public bool HoldKeyDown { get { return false; } }

    public virtual void Initiate(PlayerController player) => this.player = player;

    public abstract void TriggerAction();

    public virtual void DashDirection(Direction faceDirection)
    {

        if (player.lastDashTime + player.dashCooldown < Time.time)
        {
            player.rigidbody.velocity = new Vector2(player.dashForce * (float)faceDirection, player.dashForce); ;
            player.lastDashTime = Time.time;
        }
    }
}

public class DashRight : Dash
{
    public override void TriggerAction() => DashDirection(Direction.Right);
}

public class DashLeft : Dash
{
    public override void TriggerAction() => DashDirection(Direction.Left);
}
