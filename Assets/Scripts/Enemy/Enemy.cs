using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : SpawnableObject<Enemy>
{
    [SerializeField] private float _delay;

    private Animator _animator;
    private Vector3 _offset;
    private Coroutine _coroutine;
    private Jet[] _jets;

    public event Action<Vector3> Fired;
    public event Action<Enemy> Exploded;

    protected override Enemy Self => this;

    private void Awake()
    {
        float xOffset = -0.23f;
        _offset = new Vector3(xOffset, 0, 0);

        _animator = GetComponent<Animator>();

        _jets = Jet.GetJets(transform);
    }

    private void OnEnable()
    {
        EnableShooting();
    }

    public override void Explode()
    {
        Exploded?.Invoke(this);

        StartCoroutine(HandleExplosion());
    }

    private void EnableShooting()
    {
        _coroutine = StartCoroutine(Shoot());
    }

    private void DisableShooting()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator HandleExplosion()
    {
        float delay = 0.4f;
        var waitForExplosion = new WaitForSeconds(delay);

        DisableShooting();

        foreach (Jet jet in _jets)
            jet.Hide();

        _animator.Play(AnimationData.s_explosion);

        yield return waitForExplosion;

        StartCoroutine(ShowScore());
    }

    private IEnumerator ShowScore()
    {
        float delay = 0.7f;
        var waitForShowScore = new WaitForSeconds(delay);

        _animator.Play(AnimationData.s_score100);

        yield return waitForShowScore;

        Die();
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return wait;

            Fired?.Invoke(transform.position + _offset);
        }
    }
}