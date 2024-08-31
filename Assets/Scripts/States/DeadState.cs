public class DeadState : State
{
    public override void Enter()
    {
        isComplete = false;

        core.animator.Play("FlyingBackDeath");
        core.animator.speed = 1;

    }

    public override void Do()
    {
    }

    public override void FixedDo()
    {
    }

    public override void Exit()
    {
    }

    public void setIsComplete()
    {
        isComplete = true;
    }

}
