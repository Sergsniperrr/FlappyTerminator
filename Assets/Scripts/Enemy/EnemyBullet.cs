using UnityEngine;

public class EnemyBullet : SpawnableObject<EnemyBullet>
{
    [SerializeField] private float _speed;

    protected override EnemyBullet Self => this;

    private void Update()
    {
        transform.Translate(-_speed * Time.deltaTime, 0, 0);
    }
}
