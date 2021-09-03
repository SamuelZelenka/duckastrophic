using UnityEngine;

public class SpriteReferences : MonoBehaviour
{
    [Header("Action Sprites")]
    public Sprite Jump;
    public Sprite MoveLeft;
    public Sprite MoveRight;
    public Sprite Dash;
    public Sprite DragObject;

    public static SpriteReferences Instance => _instance;

    private static SpriteReferences _instance;

    public void Awake()
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
