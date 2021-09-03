using UnityEngine;

public interface IAction
{
    public void TriggerAction(PlayerComponents playerComnponents);
    public Sprite GetSprite();
}
