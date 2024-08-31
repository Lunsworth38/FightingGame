using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SecondPunchState : State
{
    [SerializeField] Collider punchCollider;
    public bool playNextHit;
    public bool complete;
    public override void Enter()
    {

        canBeInterrupted = false;

        isComplete = false;

        Debug.Log("Enter second Punching State");
        core.animator.Play("HookPunch");

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

        Debug.Log("EXITSECONDPUNCHINGSTATE");
       
    }

    public void setIsComplete()
    {
        isComplete = true;
    }
}
