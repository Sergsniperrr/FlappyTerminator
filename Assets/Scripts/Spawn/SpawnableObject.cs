using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public abstract class SpawnableObject<T> : MonoBehaviour, ISpawnable
{
    public event Action<T> Died;

    protected abstract T Self { get; }

    public void Die()
    {
        Died?.Invoke(Self);
    }

    public virtual void Explode()
    {
        Die();
    }
}
