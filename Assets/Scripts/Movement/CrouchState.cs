using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is Crouched");
        movement.moveable.StartCrouching();
    }

    public override void UpdateState(MovementStateManager movement)
    {
        
    }

    public override void ExitState(MovementStateManager movement)
    {
        movement.moveable.StopCrouching();
    }
}
