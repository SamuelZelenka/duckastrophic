using System.Collections;
using System.Collections.Generic; //unused namespaces
using UnityEngine;

public class PlayerComponentService<T> where T : Component
{
    public static T instance;

    public PlayerComponentService(PlayerController player) // lambda stuff
    {
        instance = player.GetComponent<T>();
    }
}
