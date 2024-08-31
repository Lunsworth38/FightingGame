using UnityEngine;

public class StateMachine
{
    public State state;

    public delegate void OnSetCallBack();
    public void Set(State newState, bool forceReset = false, OnSetCallBack callBack = null)
    {
        Debug.Log($"STATELOG old {state} new {newState}, canInterrupt: {state?.canBeInterrupted} {canChange()} {newState}");
        if (canChange())
        {
            if (state != newState || forceReset)
            {
                Debug.Log("changing state" + newState);
                state?.Exit();
                state = newState;
                state.Initialise(this);
                state.Enter();
                if (callBack != null)
                {
                    callBack();
                }
            }
        }
        
    }

    bool canChange()
    {
        if (state != null)
        {
            return state.canBeInterrupted || (state.canBeInterrupted == false && state.isComplete) ? true : false;
        }
        return true;
    }
}
