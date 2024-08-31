using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public double keyHoldCount = 0;

    public bool shouldChargeKick = false;

    public bool complete;

    public override void Enter()
    {
        Debug.Log("EnterIdle");
        isComplete = false;
        core.animator.Play("Idle");
        core.animator.Play("IdleArmsLayer");

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
    }

}
