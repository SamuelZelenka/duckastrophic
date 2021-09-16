using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    //Sort variable order
    [HideInInspector] public List<ActionSlot> actionSlots = new List<ActionSlot>();

    private int _actionSlotIndex;

    [SerializeField, Range(1,7)] private int _actionSlotCount = 1;
    [SerializeField] private ActionSlot _actionSlotPrefab;

    private int ActionSlotIndex 
    {
        get
        {
          return _actionSlotIndex;
        }
        set
        {
            actionSlots[_actionSlotIndex].highlight.enabled = false;

            _actionSlotIndex = value % actionSlots.Count;
            if (_actionSlotIndex < 0)
            {
                _actionSlotIndex = actionSlots.Count - 1;
            }

            _actionSlotIndex = (value % _actionSlotCount + _actionSlotCount) % _actionSlotCount;
        }
    }

    private void Awake()
    {
        GameSession.player.actionBar = this;
        GenerateActionSlots(ref GameSession.player.keyboardLayout);
        actionSlots[0].actionCombo.Action = new MoveRight();
        actionSlots[0].actionCombo.Action.Initiate(GameSession.player);
        actionSlots[0].highlight.enabled = true;
    }

    public KeyCode GetKey() => actionSlots[ActionSlotIndex].actionCombo.Key;
    public IAction GetAction() => actionSlots[ActionSlotIndex].actionCombo.Action;
    public void SetKey(KeyCode key) => actionSlots[ActionSlotIndex].actionCombo.Key = key;
    public void SetAction(IAction action)
    {
        action.Initiate(GameSession.player);
        actionSlots[ActionSlotIndex].actionCombo.Action = action;
    }

    public void CheckKeys()
    {
        foreach (ActionSlot actionSlot in actionSlots)
        {
            actionSlot.CheckInput();
        }
    }
    public void SwitchAction()
    {
            ActionSlotIndex += Input.GetKey(KeyCode.LeftShift) ? -1 : 1;
            actionSlots[ActionSlotIndex].highlight.enabled = true;
    }
    public bool ContainsAction<T>() where T : IAction
    {
        foreach (ActionSlot slot in actionSlots)
        {
            if (slot.actionCombo.Action?.GetType() == typeof(T))
            {
                return true;
            }
        }
        return false;
    }

    private void GenerateActionSlots(ref KeyCode[,] keyboardLayout)
    {
        List<Vector2Int> keyboardPositions = new List<Vector2Int>();
        keyboardPositions.Add(GetRandomKeyPos(0, _actionSlotCount, 0));

        for (int keyCount = 1; keyCount < _actionSlotCount; keyCount++)
        {
            keyboardPositions.Add(GetRandomKeyPos(keyboardPositions[keyCount - 1].x + 1, _actionSlotCount, keyCount));
        }

        for (int i = 0; i < _actionSlotCount; i++)
        {
            ActionSlot newSlot = Instantiate(_actionSlotPrefab, transform);
            newSlot.name = $"Action Slot {i}";
            actionSlots.Add(newSlot);

            newSlot.actionCombo = new ActionCombo(keyboardLayout[keyboardPositions[i].x, keyboardPositions[i].y], null, newSlot.OnValueChanged);
            keyboardLayout[keyboardPositions[i].x, keyboardPositions[i].y] = KeyCode.None;

            newSlot.OnValueChanged?.Invoke();
        }
    }

    private Vector2Int GetRandomKeyPos(int minXPos, int maxKeycount, int keyCount)
    {
        const int MAX_KEYS_ROW_1 = 11, MAX_KEYS_ROW_2 = 9, MAX_KEYS_ROW_3 = 7;

        int layoutPosX = 0;
        int layoutPosY = 0;

        // Determine which row the next generated key can appear on.
        if (minXPos < MAX_KEYS_ROW_3) //Can key fit on Z-M row?
        {
            layoutPosY = Random.Range(0, 3);
        }
        else if (minXPos < MAX_KEYS_ROW_2) //Can key fit on A-L row? (Scandinavian keyboards excluded)
        {
            layoutPosY = Random.Range(0, 2);
        }

        // Max keys in a row on a standard QWERTY-keyboard is 7 (Z-M)
        Mathf.Clamp(maxKeycount, 0, 7);

        switch (layoutPosY) 
        {
            case 0:
                layoutPosX = Random.Range(minXPos, MAX_KEYS_ROW_1 - maxKeycount + keyCount);
                break;
            case 1:
                layoutPosX = Random.Range(minXPos, MAX_KEYS_ROW_2 - maxKeycount + keyCount);
                break;
            case 2:
                layoutPosX = Random.Range(minXPos, MAX_KEYS_ROW_3 - maxKeycount + keyCount);
                break;
            default:
                break;
        }
        return new Vector2Int(layoutPosX, layoutPosY);
    }
}