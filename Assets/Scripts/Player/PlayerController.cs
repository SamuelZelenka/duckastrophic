using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 200f;
    public float dashForce = 10f;
    public float lastDashTime = 0f;
    public float dashCooldown = 5f;

    private float _pickedUpOffsetY = 0.55f;
    private float _pickedUpOffsetX = 0f;

    public bool isGrounded;
    public PickUpObject heldObject = null;
    public AudioClip duckQuack;

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
    public void PickUpObject(PickUpObject pickUpObject)
    {
        AudioManager.Instance.Play(duckQuack);

        if (heldObject == null)
        {
            heldObject = pickUpObject;
            pickUpObject.transform.SetParent(transform);

            pickUpObject.transform.localPosition = new Vector2( _pickedUpOffsetX, _pickedUpOffsetY);
            pickUpObject.GetComponent<Collider2D>().enabled = false;
            pickUpObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }
    }
    public Sprite GetHat() => _hatHolder.sprite;
    public void SwapHat(ref Sprite hat)
    {
        _hatHolder.sprite = hat;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
