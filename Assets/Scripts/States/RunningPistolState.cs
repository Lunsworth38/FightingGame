using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RunningPistolState : State
{
    public GameObject aimTarget;
    public float angleToTarget;
    [SerializeField] float movementSpeed = 10f;
    ShootPistol shootPistol;

    public override void Enter()
    {
        isComplete = false;

        core.animator.Play("Running");
        core.animator.Play("PistolAim");
        core.characterControl.rig.weight = 1;
        core.animator.speed = 1;
        core.characterControl.animator.SetLayerWeight(1, 1);
        shootPistol = GetComponent<ShootPistol>();
    }

    public override void Do()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            shootPistol.shoot();
        }
        core.characterControl.playerTransform.position += new Vector3(core.characterControl.xInput * movementSpeed * Time.deltaTime, 0, 0);
        core.characterControl.playerTransform.rotation = Quaternion.LookRotation(new Vector3(core.characterControl.xInput * Time.deltaTime, 0, 0));

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
        angleToTarget = angle;
    }

}
