using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Start() // lambda stuff
    {
        PlayerComponentService<Transform>.instance.position = transform.position;
    }
}
