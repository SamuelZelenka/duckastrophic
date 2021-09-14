using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMerger : MonoBehaviour
{
    [Header("Additive Scenes")]
    [SerializeField] private string[] _scenes;

    private void Awake() // lambda stuff
    {
        MergeScenes();
    }

    private void MergeScenes()
    {
        for (int i = 0; i < _scenes.Length; i++)
        {
            SceneManager.LoadScene(_scenes[i], LoadSceneMode.Additive);
        }
    }
}
