using UnityEngine;

public class LeftState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is going left");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        movement.moveable.GoLeft();
    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}
