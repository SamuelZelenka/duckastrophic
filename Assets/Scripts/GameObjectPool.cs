using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    public int maxPoolSize;

    [HideInInspector] public GameObject prefab;

    private ObjectPool<GameObject> _pool;

    public GameObject Acquire() => _pool.Acquire();
    public void Release(GameObject releaseObject)
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
        _pool = new ObjectPool<GameObject>(() => Instantiate(prefab, transform));
    }
}