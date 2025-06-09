using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is Dashing");
        movement.moveable.Dash();
    }

    public override void UpdateState(MovementStateManager movement)
    {

    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}
