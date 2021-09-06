using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatHolder : MonoBehaviour
{
    SpriteRenderer _hatHolder;

    public void SwapHat(Sprite hat)
    {
        _hatHolder.sprite = hat;

    }
}
