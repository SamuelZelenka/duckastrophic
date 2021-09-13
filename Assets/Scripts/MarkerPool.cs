using UnityEngine;

public class MarkerPool : MonoBehaviour
{
    [Range(1,100)]public int maxPoolSize;

    public MarkerVisual prefab;

    private ObjectPool<MarkerVisual> _pool;

    public MarkerVisual Acquire() => _pool.Acquire();
    public void Release(MarkerVisual releaseObject)
    {
        if (_pool.GetPoolSize() > maxPoolSize)
        {
            Destroy(releaseObject);
            return;
        }
        _pool.Release(releaseObject);
    }

    public MarkerVisual InstantiateMarker()
    {
        return Instantiate(prefab.gameObject, transform).GetComponent<MarkerVisual>();
    }

    private void Start()
    {
        _pool = new ObjectPool<MarkerVisual>(InstantiateMarker);
    }
}