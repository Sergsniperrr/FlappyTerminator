using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool<EnemyBullet> _pool;
    [SerializeField] private EnemySpawner _enemySpawner;

    private void OnEnable()
    {
        _enemySpawner.Spawned += TakeActiveEnemy;
        _enemySpawner.Removed += ReleaseEnemy;
    }

    private void OnDisable()
    {
        _enemySpawner.Spawned -= TakeActiveEnemy;
        _enemySpawner.Removed -= ReleaseEnemy;
    }

    private void Fire(Vector3 startPosition)
    {
        EnemyBullet bullet = _pool.GetObject(startPosition);

        bullet.Died += Remove;
    }

    private void Remove(EnemyBullet bullet)
    {
        _pool.PutObject(bullet);

        bullet.Died -= Remove;
    }

    private void TakeActiveEnemy(Enemy enemy)
    {
        enemy.Fired += Fire;
    }

    private void ReleaseEnemy(Enemy enemy)
    {
        enemy.Fired -= Fire;
    }
}
