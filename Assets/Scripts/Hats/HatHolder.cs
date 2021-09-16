using UnityEngine;

public class HatHolder : MonoBehaviour
{
    private SpriteRenderer _hatHolder;

    public void SwapHat(Sprite hat) => _hatHolder.sprite = hat;
}
