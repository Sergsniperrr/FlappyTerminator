using UnityEngine;

public static class AnimationData
{
    public static readonly int s_idle = Animator.StringToHash(nameof(s_idle));
    public static readonly int s_explosion = Animator.StringToHash(nameof(s_explosion));
    public static readonly int s_score100 = Animator.StringToHash(nameof(s_score100));
}
