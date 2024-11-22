using UnityEngine;

public static class AnimationData
{
    public static readonly int s_Idle = Animator.StringToHash(nameof(s_Idle));
    public static readonly int s_Explosion = Animator.StringToHash(nameof(s_Explosion));
    public static readonly int s_Score100 = Animator.StringToHash(nameof(s_Score100));
}
