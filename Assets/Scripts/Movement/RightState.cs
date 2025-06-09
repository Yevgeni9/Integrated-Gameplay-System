using UnityEngine;

public class RightState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is going right");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        movement.moveable.GoRight();
    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}
