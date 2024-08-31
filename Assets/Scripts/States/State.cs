using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool isComplete { get; protected set; }
    protected float startTime;
    public float time => Time.time - startTime;

    protected Core core;

    public StateMachine machine;

    public StateMachine parent;

    public State state => machine.state;

    public State lowestState;

    public bool canBeInterrupted = true;

    public void SetCore(Core _core)
    {
        machine = new StateMachine();
        core = _core;
    }

    protected void Set(State newState, bool forceReset = false)
    {
        machine.Set(newState, forceReset);
    }

    public void DoBranch()
    {
        Do();
        state?.DoBranch();
    }

    public void GetCurrentState()
    {
        print("STATE1" + this + state);
        if (state != null)
        {
            state.GetCurrentState();

        } else
        {
            lowestState =  parent.state;
        }
    }

    public void FixedDoBranch()
    {
        FixedDo();
        state?.FixedDoBranch();
    }

    public virtual void Enter()
    {
    }

    public virtual void Do() 
    { 
    }

    public virtual void FixedDo()
    {
    }

    public virtual void Exit()
    {
    }

    public void Initialise(StateMachine _parent)
    {
        parent = _parent;
        isComplete = false;
        startTime = Time.time;
    }
}
   
