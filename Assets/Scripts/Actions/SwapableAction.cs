using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class SwapableAction : SwapableObject
{
    public readonly IAction[] actions = new IAction[]
    {
        new MoveLeft(),
        new MoveRight(),
        new Jump(),
        new DashLeft(),
        new DashRight(),
        new PickUp()
    };

    [HideInInspector] public  int actionIndex;

    [SerializeField] private SpriteRenderer _actionIconRenderer;

    protected void Start()
    {
        _actionIconRenderer.sprite = GetComponent<SpriteLibrary>().GetSprite("Actions", actions[actionIndex].ToString());
    }

    public override void Interact(PlayerController player)
    {
        base.Interact(player);

        IAction newAction = player.actionBar.GetAction();
        actions[actionIndex].Initiate(player);
        player.actionBar.SetAction(actions[actionIndex]);

        if (newAction == null)
        {
            Destroy(gameObject);
        }
        else
        {
            actions[actionIndex] = newAction;
            _actionIconRenderer.sprite = GetComponent<SpriteLibrary>().GetSprite("Actions", actions[actionIndex].ToString());
        }
    }
}
