using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 200f;
    public float dashForce = 10f;
    public float lastDashTime = 0f;
    public float dashCooldown = 5f;

    public float pickedUpOffsetY = 0.55f;
    public float pickedUpOffsetX = 0f;

    public bool isGrounded;
    public AudioClip duckQuack;
    public PickUpObject heldObject = null;
    public InteractionController interactionController;
    public ActionBar actionBar;

    [SerializeField] private SpriteRenderer _hatHolder;

    private bool _isFacingRight;

    public KeyCode[,] keyboardLayout = new KeyCode[10, 3]
    { 
        //Keyboard layout
        { KeyCode.Q, KeyCode.A, KeyCode.Z },
        { KeyCode.W, KeyCode.S, KeyCode.X },
        { KeyCode.E, KeyCode.D, KeyCode.C },
        { KeyCode.R, KeyCode.F, KeyCode.V },
        { KeyCode.T, KeyCode.G, KeyCode.B },
        { KeyCode.Y, KeyCode.H, KeyCode.N },
        { KeyCode.U, KeyCode.J, KeyCode.M },
        { KeyCode.I, KeyCode.K, KeyCode.None },
        { KeyCode.O, KeyCode.L, KeyCode.None },
        { KeyCode.P, KeyCode.None, KeyCode.None }
    };

    public bool IsFacingRight
    {

        get
        {
            return _isFacingRight;
        }
        set
        {
            _isFacingRight = value;
            PlayerComponentService<SpriteRenderer>.instance.flipX = !_isFacingRight;
        }

    }

    private void Awake()
    {
        lastDashTime = dashCooldown;
        new PlayerComponentService<Rigidbody2D>(this);
        new PlayerComponentService<PlayerController>(this);
        new PlayerComponentService<SpriteRenderer>(this);
        new PlayerComponentService<Transform>(this);
    }
    private void Update()
    {
        PlayerComponentService<PlayerController>.instance.actionBar.CheckKeys();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            interactionController.ClosestInteractable?.Interact();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayerComponentService<PlayerController>.instance.actionBar.SwitchAction();
        }
    }
    public Sprite GetHat() => _hatHolder.sprite;
    public void SwapHat(ref Sprite hat)
    {
        _hatHolder.sprite = hat;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
