using UnityEngine;

public struct ActionCombo
{
    public delegate void ActionHandler();
    private ActionHandler onValueChanged;

    private KeyCode _key;
    private IAction _action;

    public KeyCode Key
    {
        get
        {
            return _key;
        }
        set
        {
            _key = value;
            onValueChanged?.Invoke();
        }
    }
    public IAction Action
    {
        get
        {
            return _action;
        }
        set
        {
            _action = value;
            onValueChanged?.Invoke();
        }
    }
    public ActionCombo(KeyCode key, IAction action, ActionHandler onValueChanged)
    {
        _key = key;
        _action = action;
        this.onValueChanged = onValueChanged;
    }
}