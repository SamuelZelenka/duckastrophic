using System;
using System.Collections.Generic;

public class ObjectPool<T> where T : new()
{
    delegate T CreationHandler();
    CreationHandler OnCreate;

    private Queue<T> _pool = new Queue<T>();

    public ObjectPool()
    {
        OnCreate = () => new T();
    }
    public ObjectPool(Func<T> createFunction)
    {
        OnCreate = createFunction.Invoke;
    }

    public T Acquire()
    {
        T poolObject;

        if (_pool.Count > 0)
        {
            poolObject = _pool.Dequeue();
        }
        else
        {
            poolObject = OnCreate.Invoke();
        }
        return poolObject;
    }
    public void Release(T returnObject)
    {
        _pool.Enqueue(returnObject);
    }
    public int GetPoolSize() => _pool.Count;
}
