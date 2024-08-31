using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ThirdPunchState : State
{
    [SerializeField] Collider punchCollider;
    public bool playNextHit; 
    public override void Enter()
    {
        canBeInterrupted = false;

        Debug.Log("Enter Third Punching State");

        isComplete = false;

        core.animator.Play("RoundhouseKick");
        core.animator.speed = 1;

    }

    public override void Do()
    {
    }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
        Debug.Log("EXIT");
        setArmsLayerZeroWeight();
        core.animator.Play("IdleArmsLayer");
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
