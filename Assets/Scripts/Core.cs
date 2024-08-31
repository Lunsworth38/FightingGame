using UnityEngine;

public class Core : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;

    public characterControl characterControl;

    public StateMachine machine;

    public void SetupInstances()
    {
        machine = new StateMachine();

        State[] allChildStates = GetComponentsInChildren<State>();
        foreach (State state in allChildStates)
        {
            state.SetCore(this);
        }
     }
}
