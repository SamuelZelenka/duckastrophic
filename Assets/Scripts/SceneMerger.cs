using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMerger : MonoBehaviour
{
    [Header("Additive Scenes")]
    [SerializeField] private string[] scenes;
    private void Awake()
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            SceneManager.LoadScene(scenes[i], LoadSceneMode.Additive);
        }
    }
}
