using UnityEngine;

public enum Direction { Left = -1, Right = 1 }

public interface IAction
{
    public bool HoldKeyDown { get; }
    public void TriggerAction();
    public void Initiate();
}
