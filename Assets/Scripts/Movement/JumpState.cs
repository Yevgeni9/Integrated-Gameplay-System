using UnityEngine;

public class JumpState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is jumping");
        movement.moveable.Jump();
    }

    public override void UpdateState(MovementStateManager movement)
    {

    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}
