using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerView _view;
    [SerializeField] private PlayerMover _mover;

    public event Action Died;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ISpawnable spawnableObject))
            spawnableObject.Explode();

        if (collision.TryGetComponent(out Rocket _))
            return;

        Die();
    }

    public void AllReset()
    {
        _mover.EnablePhisic();
        _mover.ResetPosition();
        _mover.ResetVelocityOnY();
        _view.Show();
    }

    public void Show()
    {
        _view.Show();
    }

    private void Die()
    {
        StartCoroutine(HandleDie());
    }

    private IEnumerator HandleDie()
    {
        float delay = 0.4f;
        var wait = new WaitForSeconds(delay);

        _mover.DisablePhisic();
        _view.ShowExplosion();

        yield return wait;

        _view.Hide();

        Died?.Invoke();
    }
}
