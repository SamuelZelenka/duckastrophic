using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DroppedKeyCode : DroppedKey
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private TMP_Text _keyText;

    protected override void Awake()
    {
        base.Awake();
        _key = (KeyCode)UnityEngine.Random.Range(97, 122);
        _keyText.text = _key.ToString();
    }
    public override void Interact()
    {
        KeyCode newKey = GameSession.Instance.actionBar.GetKey();
        GameSession.Instance.actionBar.SetKey(_key);
        if (newKey == KeyCode.None)
        {
            Destroy(gameObject);
        }
        else
        {
            _key = newKey;
            _keyText.text = _key.ToString();
        }
    }
}
