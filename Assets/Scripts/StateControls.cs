using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateControls : MonoBehaviour
{
    [SerializeField] characterControl characterControl;

    // Start is called before the first frame update
    public void setPunchingStateComplete()
    {
        Debug.Log("setPunchingStateComplete");
        characterControl.punchingState.setIsComplete();
    }
    public void setSecondPunchStateComplete()
    {
        Debug.Log("setSecondPunchingStateComplete");
        characterControl.secondPunchState.setIsComplete();
    }

    public void setThirdPunchStateComplete()
    {
        Debug.Log("setPunchingStateComplete");
        characterControl.thirdPunchState.setIsComplete();
    }

    public void setChargedKickStateComplete()
    {
        Debug.Log("setPunchingStateComplete");
        characterControl.chargedKickState.setIsComplete();
    }
    public void setHeadHitStateComplete()
    {
        Debug.Log("setHeadHitStateComplete");
        characterControl.hitState.setIsComplete();
    }

}
