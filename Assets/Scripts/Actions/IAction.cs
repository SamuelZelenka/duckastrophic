public interface IAction
{
    public bool HoldKeyDown { get; }
    public void TriggerAction();
    public void Initiate(PlayerController player);
}
