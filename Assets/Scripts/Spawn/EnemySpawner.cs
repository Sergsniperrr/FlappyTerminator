using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool<Enemy> _pool;
    [SerializeField] private float _delay;

    private readonly float _maxCoordinateY = 3.78f;
    private readonly float _minCoordinateY = -2.6f;

    public event Action<Enemy> Spawned;
    public event Action<Enemy> Removed;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_delay);
        Vector3 spawnPoint;

        while (enabled)
        {
            yield return wait;

            spawnPoint = transform.position;
            spawnPoint.y = UnityEngine.Random.Range(_minCoordinateY, _maxCoordinateY);
            Enemy enemy = _pool.GetObject(spawnPoint);

            Jet[] jets = Jet.GetJets(enemy.transform);

            foreach (Jet jet in jets)
                jet.Show();

            Spawned?.Invoke(enemy);
            enemy.Died += Remove;
        }
    }

    private void Remove(Enemy enemy)
    {
        Removed?.Invoke(enemy);
        _pool.PutObject(enemy);
        enemy.Died -= Remove;
    }
}
