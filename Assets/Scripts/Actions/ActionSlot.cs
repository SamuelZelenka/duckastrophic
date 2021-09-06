using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour
{
    public ActionCombo.ActionHandler onValueChanged;
    
    public ActionCombo actionCombo;
    public Image highlight;
    [SerializeField] private TMP_Text keyText;
    [SerializeField] private Image _playerActionIcon;

    private void Awake()
    {
        highlight.enabled = false;
        actionCombo = new ActionCombo(KeyCode.None, null, onValueChanged);
        onValueChanged += UpdateVisuals;
    }
    public void CheckInput()
    {
        if (Input.GetKey(actionCombo.Key) && actionCombo.Action != null)
        {
            actionCombo.Action.TriggerAction();
        }
    }

    private void UpdateVisuals()
    {
        keyText.text = actionCombo.Key == KeyCode.None ? "" : actionCombo.Key.ToString();
        if (actionCombo.Action != null)
        {
            _playerActionIcon.enabled = true;
            _playerActionIcon.sprite = actionCombo.Action.GetSprite();
        }
        else
        {
            _playerActionIcon.enabled = false;
        }
    }
}