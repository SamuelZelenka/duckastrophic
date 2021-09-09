using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    void Start()
    {
        PlayerComponentService<Transform>.instance.position = transform.position;
    }
}
