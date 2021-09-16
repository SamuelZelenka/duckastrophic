using TMPro;
using UnityEngine;
public class SwapableKey : SwapableObject
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private TMP_Text _keyText;

    protected void Start()
    {
        PlayerController player = PlayerComponentService<PlayerController>.instance;
        KeyCode randomKey;
        
        do
        {
            int randomX, randomY;
            randomX = UnityEngine.Random.Range(0, player.keyboardLayout.GetLength(0));
            randomY = UnityEngine.Random.Range(0, player.keyboardLayout.GetLength(1));

            randomKey = player.keyboardLayout[randomX, randomY];
            for (int i = 0; i < player.actionBar.actionSlots.Count; i++)
            {
                if (player.actionBar.actionSlots[i].actionCombo.Key == randomKey)
                {
                    randomKey = KeyCode.None;
                }
            }
            if (randomKey != KeyCode.None)
            {
                player.keyboardLayout[randomX, randomY] = KeyCode.None;
                break;
            }


        } while (randomKey == KeyCode.None);

        _key = randomKey;
        _keyText.text = _key.ToString();
    }
    public override void Interact()
    {
        PlayerController player = PlayerComponentService<PlayerController>.instance;

        KeyCode newKey = player.actionBar.GetKey();
        player.actionBar.SetKey(_key);
        
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
