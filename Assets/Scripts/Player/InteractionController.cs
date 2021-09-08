using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public delegate void InteractionHandler();
    public InteractionHandler OnClosestInteractableChange;

    [SerializeField] private float _radius;

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
    void FixedUpdate()
    {
        FindClosestInteractable();
    }

    private void FindClosestInteractable()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, LayerMask.GetMask("Interactable"));
        if (colliders.Length > 0)
        {
            ClosestInteractable = colliders[0].GetComponent<IInteractable>();

            for (int i = 0; i < colliders.Length; i++)
            {
                IInteractable interactable = colliders[i].GetComponent<IInteractable>();

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