using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("Is Idle");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movement.SwitchState(movement.leftState);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            movement.SwitchState(movement.rightState);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            movement.SwitchState(movement.jumpState);
        }
    }

    public override void OnCollisionEnter(MovementStateManager movement)
    {

    }
}
