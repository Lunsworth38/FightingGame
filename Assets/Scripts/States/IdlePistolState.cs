using UnityEngine;

public class IdlePistolState : State
{
    public float angleToTarget;
    public GameObject aimTarget;
    ShootPistol shootPistol;


    public override void Enter()
    {
        isComplete = false;
        core.animator.Play("Idle");
        core.animator.Play("PistolAim");
        core.characterControl.rig.weight = 1;
        core.animator.speed = 1;
        core.characterControl.animator.SetLayerWeight(1, 1);
        shootPistol = GetComponent<ShootPistol>();
    }

    public override void Do()
    {
       
        calculateTurn();
        if (Input.GetButtonDown(core.characterControl.shootButton))
        {
            shootPistol.shoot();
        }
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
        if (angle < 90)
        {
            core.characterControl.playerTransform.rotation = Quaternion.LookRotation(-core.characterControl.playerTransform.forward, Vector3.up);
        }
    }

}
