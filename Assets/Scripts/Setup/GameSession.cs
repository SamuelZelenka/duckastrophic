using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance => _instance;

    public ActionBar actionBar;

    [Range(1,10)]public int ActionBarCount = 2;

    private static GameSession _instance;
    private void Awake()
    {
        Load();
    }
    public void Load()
    {
        DontDestroyOnLoad(this);
        if (_instance == null)
        {
            _instance = this; 
        }
        else
        {
            Destroy(this);   
        }
    }
}
