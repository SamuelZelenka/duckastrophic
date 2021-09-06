using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    private const int ACTION_SLOT_COUNT = 3;
    private readonly KeyCode[,] keyboardLayout = new KeyCode[10, 3] 
    { 
        //Keyboard layout
        { KeyCode.Q, KeyCode.A, KeyCode.Z },
        { KeyCode.W, KeyCode.S, KeyCode.X },
        { KeyCode.E, KeyCode.D, KeyCode.C },
        { KeyCode.R, KeyCode.F, KeyCode.V },
        { KeyCode.T, KeyCode.G, KeyCode.B },
        { KeyCode.Y, KeyCode.H, KeyCode.N },
        { KeyCode.U, KeyCode.J, KeyCode.M },
        { KeyCode.I, KeyCode.K, KeyCode.None },
        { KeyCode.O, KeyCode.L, KeyCode.None },
        { KeyCode.P, KeyCode.None, KeyCode.None }
    };

    [SerializeField] private ActionSlot _actionSlotPrefab;
    [SerializeField] private Transform _highlight;

    private List<ActionSlot> _actionSlots = new List<ActionSlot>();
    private int _actionSlotIndex;

    private int ActionSlotIndex 
    {
        get
        {
          return _actionSlotIndex;
        }
        set
        {
            _actionSlots[_actionSlotIndex].highlight.enabled = false;
            _actionSlotIndex = value % _actionSlots.Count;
            if (_actionSlotIndex < 0)
            {
                _actionSlotIndex = _actionSlots.Count - 1;
            }
        }
    }

    private void Start()
    {
        GameSession.Instance.actionBar = this;
        GenerateActionSlots();
        _actionSlots[0].highlight.enabled = true;
    }
    public void SetKey(KeyCode key) => _actionSlots[_actionSlotIndex].actionCombo.Key = key;
    public void SetAction(IAction action) => _actionSlots[_actionSlotIndex].actionCombo.Action = action;
    public KeyCode GetKey() => _actionSlots[_actionSlotIndex].actionCombo.Key;
    public IAction GetAction() => _actionSlots[_actionSlotIndex].actionCombo.Action;

    public void CheckKeys()
    {
        foreach (ActionSlot actionSlot in _actionSlots)
        {
            actionSlot.CheckInput();
        }
    }
    public void SwitchAction()
    {
            ActionSlotIndex += Input.GetKey(KeyCode.LeftShift) ? -1 : 1;
            _actionSlots[_actionSlotIndex].highlight.enabled = true;
    }

    private void GenerateActionSlots()
    {
        List<Vector2Int> keyboardPositions = new List<Vector2Int>();
        keyboardPositions.Add(GetRandomKeyPos(0, ACTION_SLOT_COUNT, 0));

        for (int keyCount = 1; keyCount < ACTION_SLOT_COUNT; keyCount++)
        {
            keyboardPositions.Add(GetRandomKeyPos(keyboardPositions[keyCount - 1].x + 1, ACTION_SLOT_COUNT, keyCount));
        }

        for (int i = 0; i < ACTION_SLOT_COUNT; i++)
        {
            ActionSlot newSlot = Instantiate(_actionSlotPrefab, transform);
            newSlot.name = $"Action Slot {i}";
            _actionSlots.Add(newSlot);

            newSlot.actionCombo = new ActionCombo(keyboardLayout[keyboardPositions[i].x, keyboardPositions[i].y], null, newSlot.onValueChanged);

            newSlot.onValueChanged?.Invoke();
        }
    }

    private Vector2Int GetRandomKeyPos(int minXPos, int maxKeycount, int keyCount)
    {
        const int MAX_KEYS_ROW_1 = 11, MAX_KEYS_ROW_2 = 9, MAX_KEYS_ROW_3 = 7;

        int layoutPosX = 0;
        int layoutPosY = 0;

        if (minXPos < MAX_KEYS_ROW_3)
        {
            layoutPosY = Random.Range(0, 3);
        }
        else if (minXPos < MAX_KEYS_ROW_2)
        {
            layoutPosY = Random.Range(0, 2);
        }

        // Max keys in a row on a standard QWERTY-keyboard is 7
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