public abstract class BoyBaseState
{
    public abstract void EnterState(BoyStateMachine stateMachine);
    public abstract void UpdateState(BoyStateMachine stateMachine);
    public abstract void ExitState(BoyStateMachine stateMachine);
}