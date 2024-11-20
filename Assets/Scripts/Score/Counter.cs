using System;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;

    private readonly int pointsForMoveEnemy = 20;
    private readonly int pointsForHitEnemy = 100;

    private int _value;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _spawner.Spawned += TakeLiveEnemy;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= TakeLiveEnemy;
    }

    public void ResetValue()
    {
        _value = 0;

        ScoreChanged?.Invoke(_value);
    }

    private void AddPointsForMoveEnemy(Enemy enemy)
    {
        _value += pointsForMoveEnemy;

        ScoreChanged?.Invoke(_value);

        ReleaseLiveEnemy(enemy);
    }

    private void AddPointsForHitEnemy(Enemy enemy)
    {
        _value += pointsForHitEnemy;

        ScoreChanged?.Invoke(_value);

        ReleaseLiveEnemy(enemy);
    }

    private void TakeLiveEnemy(Enemy enemy)
    {
        enemy.Died += AddPointsForMoveEnemy;
        enemy.Exploded += AddPointsForHitEnemy;
    }

    private void ReleaseLiveEnemy(Enemy enemy)
    {
        enemy.Died -= AddPointsForMoveEnemy;
        enemy.Exploded -= AddPointsForHitEnemy;
    }
}
