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

    public bool isFacingRight;
    public bool isGrounded;
    public AudioClip duckQuack;
    public PickUpObject heldObject = null;


    [SerializeField] private InteractionController _interactionController;
    [SerializeField] private SpriteRenderer _hatHolder;

    private void Awake()
    {
        _interactionController = GetComponent<InteractionController>();
        lastDashTime = dashCooldown;
        new PlayerComponentService<Rigidbody2D>(this);
        new PlayerComponentService<PlayerController>(this);
        new PlayerComponentService<SpriteRenderer>(this);
        new PlayerComponentService<InteractionController>(this);
        new PlayerComponentService<Transform>(this);
    }
    private void Update()
    {
        GameSession.Instance.actionBar.CheckKeys();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _interactionController.ClosestInteractable?.Interact();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameSession.Instance.actionBar.SwitchAction();
        }
    }
    public Sprite GetHat() => _hatHolder.sprite;
    public void SwapHat(ref Sprite hat)
    {
        _hatHolder.sprite = hat;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            isGrounded = true;
    }
}
