using UnityEngine;

public class PlayerComponentervice<T> where T : Component
{
    public static T instance;

    public PlayerComponentervice(PlayerController player) => instance = player.GetComponent<T>();
}
