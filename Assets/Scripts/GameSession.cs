using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static PlayerController player;
    [SerializeField] PlayerController prefab;
    public Transform startPos;

    public static GameSession Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;

        PlayerController[] playerObjects = FindObjectsOfType<PlayerController>();
        for (int i = 0; i < playerObjects.Length; i++)
        {
            Destroy(playerObjects[i].gameObject);
        }
        if (FindObjectOfType<PlayerController>() == null)
        {
            player = Instantiate(prefab.gameObject, startPos.position, Quaternion.identity).GetComponent<PlayerController>();
        }
    }
}