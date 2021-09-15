using TMPro;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UI;

public class ActionSlot : MonoBehaviour
{
    public ActionCombo.ActionHandler onValueChanged; //Should be UpperCase O
    
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
        if (actionCombo.Action != null)
        {
            if (actionCombo.Action.HoldKeyDown)
            {
                TriggerAction(Input.GetKey(actionCombo.Key));
            }
            else
            {
                TriggerAction(Input.GetKeyDown(actionCombo.Key));
            }
        }

        void TriggerAction(bool input)
        {
            if (input && actionCombo.Action != null)
            {
                actionCombo.Action.TriggerAction();
            }
        }
    }

    private void UpdateVisuals()
    {
        keyText.text = actionCombo.Key == KeyCode.None ? "" : actionCombo.Key.ToString();
        if (actionCombo.Action != null)
        {
            _playerActionIcon.enabled = true;
            _playerActionIcon.sprite = GetComponent<SpriteLibrary>().GetSprite("Actions", actionCombo.Action.ToString());
        }
        else
        {
            _playerActionIcon.enabled = false;
        }
    }
}