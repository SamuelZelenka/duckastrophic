using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponentService<T> where T : Component
{
    public static T instance;

    public PlayerComponentService(PlayerController player)
    {
        instance = player.GetComponent<T>();
    }
}
