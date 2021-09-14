using System;
using System.Collections;
using System.Collections.Generic; //Remove Unused namespaces
using TMPro;
using UnityEngine;
public class SwapableKey : SwapableObject
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private TMP_Text _keyText;

    protected void Start() //Make playercontroller varaible for readability
    {
        KeyCode randomKey;
        int safety = 0; //Do we dare to remove the safety now?!
        do
        {
            int randomX, randomY;
            randomX = UnityEngine.Random.Range(0, PlayerComponentService<PlayerController>.instance.keyboardLayout.GetLength(0));
            randomY = UnityEngine.Random.Range(0, PlayerComponentService<PlayerController>.instance.keyboardLayout.GetLength(1));

            randomKey = PlayerComponentService<PlayerController>.instance.keyboardLayout[randomX, randomY];
            for (int i = 0; i < PlayerComponentService<PlayerController>.instance.actionBar.actionSlots.Count; i++)
            {
                if (PlayerComponentService<PlayerController>.instance.actionBar.actionSlots[i].actionCombo.Key == randomKey)
                {
                    randomKey = KeyCode.None;
                }
            }
            if (randomKey != KeyCode.None)
            {
                PlayerComponentService<PlayerController>.instance.keyboardLayout[randomX, randomY] = KeyCode.None;
                break;
            }

            safety++;
            if (safety > 1000)
            {
                Debug.Log("Safety triggered");
            }
        } while (randomKey == KeyCode.None || safety > 1000);

        _key = randomKey;
        _keyText.text = _key.ToString();
    }
    public override void Interact() //Make playercontroller varaible for readability
    {
        KeyCode newKey = PlayerComponentService<PlayerController>.instance.actionBar.GetKey();
        PlayerComponentService<PlayerController>.instance.actionBar.SetKey(_key);
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
