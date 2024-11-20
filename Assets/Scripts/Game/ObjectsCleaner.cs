using UnityEngine;

public class ObjectsCleaner : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemies;
    [SerializeField] private BulletPool _bullets;
    [SerializeField] private Rocket _rocket;

    public void Clear()
    {
        _enemies.Reset();
        _bullets.Reset();
        _rocket.Remove();
    }
}
