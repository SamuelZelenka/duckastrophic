using UnityEngine;

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

    private Rigidbody2D _rigidbody;
    [SerializeField] private SpriteRenderer _hatHolder;

    private Direction _faceDirection;

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
        _rigidbody = GetComponent<Rigidbody2D>();
        new PlayerComponentService<Rigidbody2D>(this);
        new PlayerComponentService<PlayerController>(this);
        new PlayerComponentService<SpriteRenderer>(this);
        new PlayerComponentService<Transform>(this);
        new PlayerComponentService<Animator>(this);
    }

    private void Update()
    {
        actionBar.CheckKeys();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            interactionController.ClosestInteractable?.Interact();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            actionBar.SwitchAction();
        }
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.x < 0.1f &&_rigidbody.velocity.x > -0.1f)
        {
            GetComponent<Animator>().SetBool("Running", false);
        }
        if (_rigidbody.velocity.y <= 0.1f && _rigidbody.velocity.y >= -0.1f)
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
