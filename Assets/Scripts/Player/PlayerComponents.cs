using UnityEngine;

public struct PlayerComponents
{
    
    public PlayerController Controller => _controller;
    public Rigidbody2D RigidBody => _rigidbody;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public Transform Transform => _controller.transform;
    public InteractionController InteractionController => _interactionController;

    private PlayerController _controller;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private InteractionController _interactionController;

    public PlayerComponents(PlayerController controller, Rigidbody2D rigidbody, SpriteRenderer spriteRenderer, InteractionController interactionController)
    {
        _controller = controller;
        _rigidbody = rigidbody;
        _spriteRenderer = spriteRenderer;
        _interactionController = interactionController;
    }
}