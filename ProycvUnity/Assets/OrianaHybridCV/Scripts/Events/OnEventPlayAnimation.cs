using UnityEngine;
using System.Collections;

public class OnEventPlayAnimation : OnEvent<PlayAnimation>
{
}

[System.Serializable]
public class PlayAnimation : EventExecuterBase
{
    public Animator animator = null;
    public string animationName = "";

    public override void DoAction()
    {
        animator.Play(animationName);
    }
}