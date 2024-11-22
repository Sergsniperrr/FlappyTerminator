using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemies;
    [SerializeField] private BulletPool _bullets;
    [SerializeField] private Rocket _rocket;
    [SerializeField] private Counter _score;

    public void Clear()
    {
        _enemies.Reset();
        _bullets.Reset();
        _rocket.Remove();
        _score.ResetValue();
    }
}
