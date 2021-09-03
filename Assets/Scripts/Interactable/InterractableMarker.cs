using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractableMarker : MonoBehaviour
{

    [Range(0, 25)] public int markerCount = 3;

    public float radius = 2;
    public IInteractable interactable;

    [SerializeField] private GameObjectPool _pool;
    [SerializeField] private GameObject _markerPrefab;

    [SerializeField] private Vector2 posOffset;


    private List<GameObject> _markers = new List<GameObject>();
    private float angleOffset = 0;

    private void Start()
    {
        if (interactable == null)
        {
            Debug.LogError("Interactable component is missing.");
            return;
        }
        
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        _pool.prefab = _markerPrefab;
        interactable = transform.GetComponentInParent<IInteractable>();

        interactable.Highlight = this;
    }

    public GameObjectPool FindObjectPool()
    {
        GameObjectPool[] pools;
        pools = FindObjectsOfType<GameObjectPool>();
        for (int i = 0; i < pools.Length; i++)
        {
            if (pools[i].IsTypeOf<IInteractable>())
            {
                return pools[i];
            }
        }

        return new  GameObject().AddComponent<GameObjectPool>();
    }

    public void GetMarkers()
    {
        if (GameSession.Instance.playerComponents.InteractionController.ClosestInteractable == interactable && !interactable.IsHighlighted)
        {
            for (int i = 0; i < markerCount; i++)
            {
                _markers.Add(_pool.Acquire());
                _markers[_markers.Count - 1].SetActive(true);
            }
        }
    }
    public void ReleaseMarkers()
    {
        for (int i = 0; i < _markers.Count; i++)
        {
            _markers[i].SetActive(false);
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
