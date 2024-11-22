using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Renderer))]
public class PlayerView : MonoBehaviour
{
    private Jet _jet;
    private Animator _animator;
    private Renderer _renderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<Renderer>();

        _jet = JetSearcher.GetOne(transform);

        Hide();
    }

    public void ShowExplosion()
    {
        _jet.Hide();
        _animator.Play(AnimationData.s_Explosion);
    }

    public void Hide()
    {
        _renderer.enabled = false;
        _jet.Hide();
    }

    public void Show()
    {
        _renderer.enabled = true;
        _animator.Play(AnimationData.s_Idle);
        _jet.Show();
    }
}
