using UnityEngine;

public class PunchingState : State
{
    [SerializeField] Collider punchCollider;
   
    public bool playNextHit;
    public bool complete;

    public override void Enter()
    {
        isComplete = false;
        playNextHit = false;
        canBeInterrupted = false;

        Debug.Log("Enter Punching State");
        setArmsLayerFullWeight();
        core.animator.Play("Punching");
        core.animator.Play("Idle");

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
        Debug.Log("EXITPUNCHINGSTATE");
       
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
