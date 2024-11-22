using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public abstract class SpawnableObject<T> : MonoBehaviour, ISpawnable, IRemovable
{
    public event Action<T> Died;

    protected abstract T Self { get; }

    public void Remove()
    {
        Died?.Invoke(Self);
    }

    public virtual void Explode()
    {
        Remove();
    }
}
