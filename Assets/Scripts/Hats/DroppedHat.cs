using UnityEngine;

public class DroppedHat : SwapableObject, IInteractable
{
    private Sprite _hatSprite;
    private SpriteRenderer _spriterenderer;
    protected override void Awake()
    {
        base.Awake();
        _spriterenderer = GetComponent<SpriteRenderer>();
        _hatSprite = _spriterenderer.sprite;
    }
    public override void Interact(PlayerController player)
    {
        Sprite hatFromPlayer = player.GetHat();
        _spriterenderer.sprite = hatFromPlayer;

        player.SwapHat(_hatSprite);
        _hatSprite = hatFromPlayer;
        
        if (_hatSprite == null)
        {
            Destroy(gameObject);
        }
    }
}
