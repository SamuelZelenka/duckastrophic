using UnityEngine;

public class GameSession : MonoBehaviour
{
    enum CoolEnum { CoolName = 32, CoolNameagain = 4, SomeOtherCoolName = 88 }
    public static GameSession Instance => _instance;

    [SerializeField] public ActionBar actionBar;
    public PlayerComponents playerComponents;

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

        PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerComponents = new PlayerComponents
            (
            playerController.GetComponent<PlayerController>(),
            playerController.GetComponent<Rigidbody2D>(),
            playerController.GetComponent<SpriteRenderer>(),
            playerController.GetComponent<InteractionController>()
            );
    }
}
