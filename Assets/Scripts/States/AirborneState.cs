using UnityEditor;
using UnityEngine;

public class Airborne : State
{
    public State currentState;

    [SerializeField] public float jumpForce;
    [SerializeField] float airMovementSpeed;
    float initialVelocity;
    public override void Enter()
    {
        isComplete = false;

    }

    public override void Do()
    {
        float time = Map(core.rb.velocity.y, jumpForce, -jumpForce, 0, 1, true);
        core.animator.Play("Jumping", 0, time);
        core.animator.speed = 0;
        core.characterControl.playerTransform.position += new Vector3(core.characterControl.xInput * airMovementSpeed * Time.deltaTime, 0, 0);
        //input.playerTransform.rotation = Quaternion.LookRotation(new Vector3(input.xInput * Time.deltaTime, 0, 0));
        currentState = machine.state;
    }

    public override void FixedDo()
    {
        float absoluteInput = Mathf.Abs(core.characterControl.xInput);
        float clampedInput = Mathf.Clamp(absoluteInput, 0f, 0.3f);
        if (core.characterControl.xInput < 0)
        {
            clampedInput = -clampedInput;
        }
        var position = core.characterControl.playerTransform.position;

    }

    public override void Exit()
    {

    }

    public static float Map(float value, float min1, float max1, float min2, float max2, bool clamp = false)
    {
        float val = min2 + (max2 - min2) * ((value - min1) / (max1 - min1));
        return clamp ? Mathf.Clamp(val, Mathf.Min(min2, max2), Mathf.Max(min2, max2)) : val;
    }
}
