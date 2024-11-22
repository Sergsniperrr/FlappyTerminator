using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Jet : MonoBehaviour 
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void Hide()
    {
        _renderer.enabled = false;
    }

    public void Show()
    {
        _renderer.enabled = true;
    }
}
