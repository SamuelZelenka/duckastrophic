using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMarker : MonoBehaviour
{
    [Range(0, 25)] public int markerCount = 3;

    public float radius = 1;
    public IInteractable interactable;

    [SerializeField] private Vector2 posOffset;

    private MarkerPool _pool;

    private List<MarkerVisual> _markers = new List<MarkerVisual>();
    private float angleOffset = 0;

    private void Start()
    {
        interactable = transform.GetComponentInParent<IInteractable>();
        if (interactable == null)
        {
            Debug.LogError($"Interactable component is missing on GameObject <{gameObject.name}> ID:{gameObject.GetInstanceID()}.");
            return;
        }
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogError($"Collider2D is missing on GameObject <{gameObject.name}> ID:{gameObject.GetInstanceID()}.");
            return;
        }
        _pool = FindObjectPool();
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        
        interactable.Highlight = this;
    }

    public MarkerPool FindObjectPool()
    {
        MarkerPool[] pools;
        pools = FindObjectsOfType<MarkerPool>();
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].GetType() == typeof(MarkerPool))
            {
                return pools[i];
            }
        }

        return new  GameObject().AddComponent<MarkerPool>();
    }

    public void GetMarkers()
    {
        if (PlayerComponentService<InteractionController>.instance.ClosestInteractable == interactable && !interactable.IsHighlighted)
        {
            for (int i = 0; i < markerCount; i++)
            {
                _markers.Add(_pool.Acquire());
                _markers[_markers.Count - 1].gameObject.SetActive(true);
            }
        }
    }
    public void ReleaseMarkers()
    {
        for (int i = 0; i < _markers.Count; i++)
        {
            _markers[i].gameObject.SetActive(false);
            _pool.Release(_markers[i]);
        }
        _markers.Clear();
    }

    private void Update()
    {
        angleOffset += 1 * Time.deltaTime;
        for (int i = 0; i < _markers.Count; i++)
        {
            _markers[i].transform.position = CalculatePointPosition(i);
        }
    }

    Vector2 CalculatePointPosition(int currrentPointCount)
    {
        float theta = ((Mathf.PI * 2) / markerCount);
        float angle = (theta * currrentPointCount);

        return new Vector2(radius * Mathf.Cos(angle + angleOffset), radius * Mathf.Sin(angle + angleOffset)) + (Vector2)transform.position + posOffset;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (gameObject.activeSelf)
        {
            for (int i = 0; i < markerCount; i++)
            {
                Gizmos.DrawSphere(CalculatePointPosition(i), 0.1f);
            }
        }
    }
#endif
}
