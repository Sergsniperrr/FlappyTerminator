using System.Collections.Generic;
using UnityEngine;

public static class JetSearcher
{
    public static Jet[] GetFew(Transform parent)
    {
        List<Jet> result = new();

        foreach (Transform childTransform in parent)
            if (childTransform.TryGetComponent(out Jet jet))
                result.Add(jet);

        return result.ToArray();
    }

    public static Jet GetOne(Transform parent)
    {
        Jet result = null;

        Jet[] jets = GetFew(parent);

        if (jets.Length > 0)
            result = jets[0];

        return result;
    }
}
