using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public delegate void InteractionHandler();
    public InteractionHandler OnClosestInteractableChange;

    private List<Collider2D> _interactablesInRange = new List<Collider2D>();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            _interactablesInRange.Add(collision);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        FindClosestInteractable();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _interactablesInRange.Remove(collision);
    }

    private void FindClosestInteractable()
    {
        if (_interactablesInRange.Count > 0)
        {
            ClosestInteractable = _interactablesInRange[0].GetComponent<IInteractable>();

            for (int i = 0; i < _interactablesInRange.Count; i++)
            {
                IInteractable interactable = _interactablesInRange[i].GetComponent<IInteractable>();

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