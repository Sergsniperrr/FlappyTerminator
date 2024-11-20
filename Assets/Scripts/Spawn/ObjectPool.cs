using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : SpawnableObject<T>
{
    [SerializeField] private T[] _prefabs;
    [SerializeField] private Transform _container;

    private Queue<T> _pool;

    public IEnumerable<T> PooledObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<T>();
    }

    public T GetObject(Vector3 startPosition)
    {
        if (_pool.Count == 0)
        {
            T prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            T spawnableObject = Instantiate(prefab);

            spawnableObject.transform.parent = _container;
            spawnableObject.transform.position = startPosition;

            return spawnableObject;
        }

        T spawnedObject = _pool.Dequeue();

        spawnedObject.gameObject.SetActive(true);
        spawnedObject.transform.position = startPosition;

        return spawnedObject;
    }

    public void PutObject(T spawnableObject)
    {
        _pool.Enqueue(spawnableObject);
        
        spawnableObject.transform.position = transform.position;

        spawnableObject.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();

        Transform[] childTransforms = _container.GetComponentsInChildren<Transform>();

        foreach (var child in childTransforms)
            if (child.TryGetComponent(out ISpawnable spawnableObject))
                spawnableObject.Die();
    }
}