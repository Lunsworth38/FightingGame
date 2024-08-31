using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ChargedKickState : State
{
    [SerializeField] Collider punchCollider;
    public bool complete;

    public override void Enter()
    {
        isComplete = false;
        canBeInterrupted = false;
        Debug.Log("Enteringchargedkickstate");
        core.animator.Play("ChargedKick");
        core.animator.speed = 1;

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

    public void setArmsLayerFullWeight()
    {
        core.animator.SetLayerWeight(1, 1.0f);
    }

    public void setArmsLayerZeroWeight()
    {
        Debug.Log("SetArmsToZeroWeight");
        core.animator.SetLayerWeight(1, 0.001f);
    }

    public void setIsComplete()
    {
        isComplete = true;
    }
}
