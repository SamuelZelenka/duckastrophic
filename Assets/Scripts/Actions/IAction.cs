using UnityEngine;

public interface IAction
{
    public bool HoldKeyDown { get; } 
    public void TriggerAction();
    public Sprite GetSprite();
    public void Initiate();
}
