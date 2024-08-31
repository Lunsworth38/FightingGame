using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class HitState: State
{
    public bool complete;

    public override void Enter()
    {
        isComplete = false;
        core.animator.Play("HeadHit");
        core.animator.speed = 2;
        core.characterControl.hit = false;
    }

    public override void Do()
    {
        complete = isComplete;
    }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
        
    }

    public void setIsComplete()
    {
        Debug.Log("hitstateiscompletecalled");
        isComplete = true;
    }

}
