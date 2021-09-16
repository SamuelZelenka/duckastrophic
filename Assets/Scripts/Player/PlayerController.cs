using UnityEngine;

public enum Direction { Left = -1, Right = 1 }

public class PlayerController : MonoBehaviour
{
    public float acceleration;
    public float maxVelocity;
    public float jumpForce;
    public float dashForce;
    public float lastDashTime;
    public float dashCooldown;

    public float pickedUpOffsetY = 0.55f;
    public float pickedUpOffsetX = 0f;

    public bool isGrounded;
    public AudioClip duckQuack;
    public PickUpObject heldObject = null;
    public InteractionController interactionController;
    public ActionBar actionBar;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody;

    [SerializeField] private SpriteRenderer _hatHolder;

    private Direction _faceDirection;

    private static readonly KeyCode[,] _keyboardLayoutTemplate = new KeyCode[10, 3]
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

    public static KeyCode[,] keyboardLayout;

    public Direction FaceDirection
    {
        get
        {
            return _faceDirection;
        }
        set
        {
            _faceDirection = value;
            transform.localScale = _faceDirection == Direction.Right ? new Vector3(1, 1, 1) : new Vector3(-1,1,1);
        }
    }

    private void Awake()
    {
        lastDashTime = dashCooldown;
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        keyboardLayout = _keyboardLayoutTemplate;
        actionBar = FindObjectOfType<ActionBar>();
    }

    private void Update()
    {
        actionBar.CheckKeys();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            interactionController.ClosestInteractable?.Interact(this);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            actionBar.SwitchAction();
        }
    }

    private void FixedUpdate()
    {
        if (rigidbody.velocity.x < 0.1f && rigidbody.velocity.x > -0.1f)
        {
            GetComponent<Animator>().SetBool("Running", false);
        }
        if (rigidbody.velocity.y <= 0.1f && rigidbody.velocity.y >= -0.1f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public Sprite GetHat() => _hatHolder.sprite;

    public void SwapHat(Sprite hat) => _hatHolder.sprite = hat;
}
