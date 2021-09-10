using System;
using UnityEngine;

public class DroppedHat : SwappableObject, IInteractable
{
    private Sprite _hatSprite;
    private SpriteRenderer _spriterenderer;
    protected override void Awake()
    {
        base.Awake();
        _spriterenderer = GetComponent<SpriteRenderer>();
        _hatSprite = _spriterenderer.sprite;
    }
    public override void Interact()
    {
        Sprite hatFromPlayer = PlayerComponentService<PlayerController>.instance.GetHat();
        _spriterenderer.sprite = hatFromPlayer;
        PlayerComponentService<PlayerController>.instance.SwapHat(ref _hatSprite);
        _hatSprite = hatFromPlayer;
        if (_hatSprite == null)
        {
            Destroy(gameObject);
        }
    }
}
