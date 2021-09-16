using TMPro;
using UnityEngine;
public class SwapableKey : SwapableObject
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private TMP_Text _keyText;

    protected void Start()
    {
        KeyCode randomKey;
        
        do
        {
            int randomX, randomY;
            randomX = Random.Range(0, PlayerController.keyboardLayout.GetLength(0));
            randomY = Random.Range(0, PlayerController.keyboardLayout.GetLength(1));

            randomKey = PlayerController.keyboardLayout[randomX, randomY];
            for (int i = 0; i < GameSession.player.actionBar.actionSlots.Count; i++)
            {
                if (GameSession.player.actionBar.actionSlots[i].actionCombo.Key == randomKey)
                {
                    randomKey = KeyCode.None;
                }
            }
            if (randomKey != KeyCode.None)
            {
                PlayerController.keyboardLayout[randomX, randomY] = KeyCode.None;
                break;
            }


        } while (randomKey == KeyCode.None);

        _key = randomKey;
        _keyText.text = _key.ToString();
    }
    public override void Interact(PlayerController player)
    {
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
