using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : MovementBaseState
{
    private float dashDuration = 0.2f;
    private float dashSpeed = 20f;
    private float elapsedTime = 0f;
    private Vector2 dashDirection;

    public override void EnterState(MovementStateManager movement)
    {
        elapsedTime = 0f;

        float dir = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : movement.GetRb().velocity.x >= 0 ? 1 : -1;
        dashDirection = new Vector2(dir, 0).normalized;

        movement.GetRb().velocity = dashDirection * dashSpeed;
    }

    public override void UpdateState(MovementStateManager movement)
    {
        elapsedTime += Time.deltaTime;

        movement.GetRb().velocity = dashDirection * dashSpeed;

        if (elapsedTime >= dashDuration)
        {
            movement.SwitchState(movement.idleState);
        }
    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}
