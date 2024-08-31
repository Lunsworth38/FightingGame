using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AirbornePistolState : State
{
    public GameObject aimTarget;
    public float angleToTarget;
    ShootPistol shootPistol;
    [SerializeField] public float jumpForce;
    [SerializeField] float airMovementSpeed;

    public override void Enter()
    {
        isComplete = false;

        core.animator.Play("PistolAim");
        core.animator.Play("Jumping");
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
        float time = Map(core.rb.velocity.y, jumpForce, -jumpForce, 0, 1, true);
        core.animator.Play("Jumping", 0, time);
        core.animator.speed = 0;
        core.characterControl.playerTransform.position += new Vector3(core.characterControl.xInput * airMovementSpeed * Time.deltaTime, 0, 0);
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

    public static float Map(float value, float min1, float max1, float min2, float max2, bool clamp = false)
    {
        float val = min2 + (max2 - min2) * ((value - min1) / (max1 - min1));
        return clamp ? Mathf.Clamp(val, Mathf.Min(min2, max2), Mathf.Max(min2, max2)) : val;
    }

}
