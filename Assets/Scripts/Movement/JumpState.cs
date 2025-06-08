using UnityEngine;

public class JumpState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.moveable.Jump();
    }

    public override void UpdateState(MovementStateManager movement)
    {
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            movement.SwitchState(movement.idleState);
        }
    }

    public override void OnCollisionEnter(MovementStateManager movement)
    {

    }
}
