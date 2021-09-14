using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public delegate void InteractionHandler();
    public InteractionHandler OnClosestInteractableChange;

    private List<IInteractable> _interactablesInRange = new List<IInteractable>();

    private IInteractable _closestInteractable;
    public IInteractable ClosestInteractable
    {
        get
        {
            return _closestInteractable;
        }
        set
        {
            if (_closestInteractable != value)
            {
                if (_closestInteractable != null)
                {
                    _closestInteractable.DisableHighlight();
                }
                OnClosestInteractableChange?.Invoke();
                _closestInteractable = value;
            }
        }
    }

    // Can we find interactables without using physics to make it cheaper?
    private void OnTriggerStay2D(Collider2D collision) // lambda stuff
    {
        FindClosestInteractable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IInteractable>() != null && collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            _interactablesInRange.Add(collision.GetComponent<IInteractable>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (_interactablesInRange.Contains(interactable))
        {
            interactable.DisableHighlight();
            _interactablesInRange.Remove(collision.GetComponent<IInteractable>());
        }
    }

    private void FindClosestInteractable()
    {
        if (_interactablesInRange.Count > 0)
        {
            ClosestInteractable = _interactablesInRange[0];

            for (int i = 0; i < _interactablesInRange.Count; i++)
            {
                IInteractable interactable = _interactablesInRange[i];

                if (Vector3.Distance(interactable.Transform.position, transform.position) < Vector3.Distance(ClosestInteractable.Transform.position, transform.position) && interactable.IsInteractable())
                {
                    ClosestInteractable = interactable;
                }
            }
            if (ClosestInteractable.IsInteractable())
            {
                ClosestInteractable.EnableHighlight();
            } 
            return;
        }
        ClosestInteractable = null;
    }

    public void InteractWithClosestObject()
    {
        ClosestInteractable?.Interact();
    }
}