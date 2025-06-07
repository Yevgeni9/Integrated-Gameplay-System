using UnityEngine;

public class LeftState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("Left");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            movement.SwitchState(movement.idleState);
        }

        movement.moveable.GoLeft();
    }

    public override void OnCollisionEnter(MovementStateManager movement)
    {

    }
}
