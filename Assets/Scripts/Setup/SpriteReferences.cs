using UnityEngine;

public class SpriteReferences : Loadable
{
    [Header("Action Sprites")]
    public Sprite Jump;
    public Sprite MoveLeft;
    public Sprite MoveRight;
    public Sprite DashLeft;
    public Sprite DashRight;
    public Sprite PickUpObject;

    public static SpriteReferences Instance => _instance;

    private static SpriteReferences _instance;

    public override void Initiate()
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
    }
}
