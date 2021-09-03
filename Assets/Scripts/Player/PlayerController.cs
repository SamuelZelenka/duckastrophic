using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float jumpForce = 200f;
    public float dashForce = 10f;
    public float lastDashTime = 0f;
    public float dashCooldown = 5f;

    public bool isGrounded;
    public PickUpObject pickedUpObject = null;

    [SerializeField] private InteractionController interactionController;

    private void Awake()
    {
        interactionController = GetComponent<InteractionController>();

        lastDashTime = dashCooldown;
    }
    private void Update()
    {
        GameSession.Instance.actionBar.CheckKeys();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            interactionController.ClosestInteractable?.Interact();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameSession.Instance.actionBar.SwitchAction();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
