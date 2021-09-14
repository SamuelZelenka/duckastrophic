using System.Collections; //unused namespace
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    //Sort variables
    public static LoadManager Instance;
    public List<Loadable> loadables = new List<Loadable>();

    [SerializeField] private string gameSceneName; 

    private static LoadManager _instance;

    private void OnEnable()
    {
        DontDestroyOnLoad(this);
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        foreach (Loadable loadable in loadables)
        {
            loadable.Initiate();
        }
        SceneManager.LoadScene(gameSceneName);
    }

    public void AddLoadable(Loadable loadable) => loadables.Add(loadable);
}

// Separate script?
public abstract class Loadable : MonoBehaviour
{
    public abstract void Initiate();
}