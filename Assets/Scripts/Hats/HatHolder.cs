using System.Collections;
using System.Collections.Generic; //unused namespaces
using UnityEngine;

public class HatHolder : MonoBehaviour
{
    SpriteRenderer _hatHolder; // name inconsistency

    public void SwapHat(Sprite hat) //lambda stuff
    {
        _hatHolder.sprite = hat;
    }
}
