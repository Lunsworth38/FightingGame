using UnityEngine;

public class Running : State
{
    [SerializeField] float movementSpeed = 10f;
    public override void Enter()
    {
        core.animator.Play("Running");
        Debug.Log("Enter Running state");
        core.animator.speed = 1;

    }

    public override void Do()
    {
        Debug.Log("Do");
        Debug.Log("InRUNNINGSTATE");
        if (core.characterControl.xInput != 0)
        {
            core.characterControl.playerTransform.position += new Vector3(core.characterControl.xInput * movementSpeed * Time.deltaTime, 0, 0);
            core.characterControl.playerTransform.rotation = Quaternion.LookRotation(new Vector3(core.characterControl.xInput * Time.deltaTime, 0, 0));
        }
    }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
        Debug.Log("Exit");
    }

}
