using UnityEngine;

public class SwapableAction : SwapableObject
{
    // sort variables logically
    [HideInInspector] public  int actionIndex;
    public readonly IAction[] actions = new IAction[]
    {
        new MoveLeft(),
        new MoveRight(),
        new Jump(),
        new DashLeft(),
        new DashRight(),
        new PickUp()
    };
    [SerializeField] private SpriteRenderer _actionIconRenderer;
    protected void Start() // lambda operator stuffs
    {
        _actionIconRenderer.sprite = actions[actionIndex].GetSprite();
    }
    public override void Interact() //Make playercontroller varaible for readability
    {
        IAction newAction = PlayerComponentService<PlayerController>.instance.actionBar.GetAction();
        PlayerComponentService<PlayerController>.instance.actionBar.SetAction(actions[actionIndex]);
        if (newAction == null)
        {
            Destroy(gameObject);
        }
        else
        {
            actions[actionIndex] = newAction;
            _actionIconRenderer.sprite = actions[actionIndex].GetSprite();
        }
    }
}
