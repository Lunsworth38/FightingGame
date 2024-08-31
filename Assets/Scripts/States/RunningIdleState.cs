using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RunningState : State
{
    public GameObject aimTarget;
    [SerializeField] float movementSpeed = 10f;

    public override void Enter()
    {
        isComplete = false;
        core.animator.Play("Running");
        core.animator.Play("PistolAim");
        core.characterControl.rig.weight = 1;
        core.animator.speed = 1;
        core.characterControl.animator.SetLayerWeight(1, 1);


    }

    public override void Do()
    {
        core.characterControl.playerTransform.position += new Vector3(core.characterControl.xInput * movementSpeed * Time.deltaTime, 0, 0);
        calculateTurn();
    }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
    }
    private void calculateTurn()
    {
        Vector3 directionToAimTarget = core.characterControl.playerTransform.position - aimTarget.transform.position;
        float angle = Vector3.Angle(core.characterControl.playerTransform.forward, directionToAimTarget);
        if (angle < 90)
        {
            transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
        }
    }

}
