using UnityEngine;

public class DroppedAction : DroppedObject
{
    public  int actionIndex;
    public readonly IAction[] actions = new IAction[]
    {
        new MoveLeft(),
        new MoveRight(),
        new Jump(),
        new Dash(),
        new MoveObject(),
        new PickUp()
    };
    [SerializeField] private SpriteRenderer _actionIconRenderer;
    protected void Start()
    {
        _actionIconRenderer.sprite = actions[actionIndex].GetSprite();
    }
    public override void Interact()
    {
        IAction newAction = GameSession.Instance.actionBar.GetAction();
        GameSession.Instance.actionBar.SetAction(actions[actionIndex]);
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
