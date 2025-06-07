using UnityEngine;

public class RightState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {

    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            movement.SwitchState(movement.idleState);
        }

        movement.moveable.GoRight();
    }

    public override void OnCollisionEnter(MovementStateManager movement)
    {

    }
}
