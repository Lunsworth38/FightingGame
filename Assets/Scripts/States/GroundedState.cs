using System.Collections.Generic;
using UnityEngine;

public class GroundedState : State
{
    public State currentState;
    public double keyHoldCount;
    public double comboCounter;

    public bool shouldChargeKick = false;

    public int inputQueueCounter;

    public float bufferTimer;

    public float bufferLimit;

    public bool doingMove;


    public override void Enter()
    {
        keyHoldCount = 0;
        comboCounter = 0;
        inputQueueCounter = 0;
        SelectState(true);
    }
    public override void Do()
    {
        if (Input.GetButtonUp(core.characterControl.punchButton))
        {
            keyHoldCount = 0;
        }
        if (machine.state != core.characterControl.chargedKickState && Input.GetButton(core.characterControl.punchButton) && !core.characterControl.disableControl)
        {
            keyHoldCount = keyHoldCount + 1 * Time.deltaTime;
        }

        if (keyHoldCount >= 0.15)
        {
            shouldChargeKick = true;
            //keyHoldCount = 0;
        }

        doingMove = isDoingMove();

        if (Input.GetButtonDown(core.characterControl.punchButton))
        {
            if (inputQueueCounter < 3)
            {
                inputQueueCounter = inputQueueCounter + 1;
                bufferTimer = 0;
            }
        }
        print("COMBO" + inputQueueCounter);
        currentState = machine.state;
        SelectState();
    }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
    }

    void SelectState(bool forceReset = false)
    {
        if (core.characterControl.hasRangedWeapon)
        {
            Debug.Log("Hello1");
            machine.Set(core.characterControl.hasRangedWeaponState, forceReset);
        }
        else if (shouldChargeKick)
        {
            machine.Set(core.characterControl.chargedKickState, true);
            shouldChargeKick = false;
        }
        else if (inputQueueCounter > 0 && !doingMove)
        {
            if (comboCounter == 2)
            {
                changeComboCounter(0);
                machine.Set(core.characterControl.thirdPunchState, forceReset, () => {
                    inputQueueCounter--;
                });
            }
            else if (comboCounter == 1)
            {

                changeComboCounter(2);
                machine.Set(core.characterControl.secondPunchState, forceReset, () => {
                    inputQueueCounter--;
                });
            }
            else if (comboCounter == 0)
            {
                changeComboCounter(1);
                machine.Set(core.characterControl.punchingState, forceReset, () =>
                {
                    inputQueueCounter--;
                });

            }
        }
        else if (core.characterControl.xInput != 0)
        {
            Debug.Log("Hello2");

            machine.Set(core.characterControl.runningState, forceReset);
        }
        else if (core.characterControl.xInput == 0)
        {
            Debug.Log("Hello3");

            machine.Set(core.characterControl.idleState, forceReset);
        }
    }
    void changeComboCounter(int next)
    {
        if (comboCounter != next)
        {
            comboCounter = next;
        }
    }

    bool isDoingMove()
    {
        characterControl ctrl = core.characterControl;
        if (currentState == ctrl.punchingState || currentState == ctrl.secondPunchState || currentState == ctrl.thirdPunchState || currentState == ctrl.chargedKickState)
        {
            return true;
        } else
        {
            return false;
        }
    }

}
