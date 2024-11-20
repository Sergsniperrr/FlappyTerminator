using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Jet : MonoBehaviour 
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public static Jet[] GetJets(Transform parent)
    {
        Transform[] childTransforms = parent.GetComponentsInChildren<Transform>();
        List<Jet> result = new();

        foreach (Transform childTransform in childTransforms)
            if (childTransform.TryGetComponent(out Jet jet))
                result.Add(jet);

        return result.ToArray();
    }

    public static Jet GetJet(Transform parent)
    {
        Jet result = null;

        Jet[] jets = GetJets(parent);

        if (jets.Length > 0)
            result = jets[0];

        return result;
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
