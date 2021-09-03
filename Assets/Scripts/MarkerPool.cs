using UnityEngine;

public class MarkerPool : MonoBehaviour
{
    public int maxPoolSize;

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

    private void Start()
    {
        _pool = new ObjectPool<MarkerVisual>(() => Instantiate(prefab.gameObject, transform).GetComponent<MarkerVisual>());
    }
}