using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBaseState
{
    public abstract void EnterState(MovementStateManager movement);

    public abstract void UpdateState(MovementStateManager movement);

    public abstract void ExitState(MovementStateManager movement);
}

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is Idle");
    }

    public override void UpdateState(MovementStateManager movement)
    {

    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}

public class LeftState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is going left");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        movement.transform.Translate(Vector3.left * movement.moveSpeed * Time.deltaTime);
    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}

public class RightState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is going right");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        movement.transform.Translate(Vector3.right * movement.moveSpeed * Time.deltaTime);
    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}

public class JumpState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is jumping");
        if (!movement.isGrounded)
        {
            return;
        }

        movement.GetRb().AddForce(Vector2.up * movement.jumpForce);
        movement.isGrounded = false;
    }

    public override void UpdateState(MovementStateManager movement)
    {

    }

    public override void ExitState(MovementStateManager movement)
    {

    }
}

public class CrouchState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is Crouched");
        movement.transform.localScale = new Vector2(1, 1); // Ideally I would change a sprite here or start an animation, but for the prototype im just reducing the cube size
    }

    public override void UpdateState(MovementStateManager movement)
    {

    }

    public override void ExitState(MovementStateManager movement)
    {
        movement.transform.localScale = new Vector2(1, 2); // Reset to normal size
    }
}

public class DashState : MovementBaseState
{
    private float dashDuration = 0.15f;
    private float dashSpeed = 20f;
    private float elapsedTime = 0f;
    private Vector2 dashDirection;

    public override void EnterState(MovementStateManager movement)
    {
        movement.SetAllowInput(false);

        elapsedTime = 0f;

        float dir = Input.GetKey(KeyCode.D) ? 1 :
                    Input.GetKey(KeyCode.A) ? -1 :
                    movement.GetRb().velocity.x >= 0 ? 1 : -1;

        dashDirection = new Vector2(dir, 0).normalized;
        movement.GetRb().velocity = dashDirection * dashSpeed;
        movement.GetRb().gravityScale = 0;
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
        movement.SetAllowInput(true);
        movement.GetRb().gravityScale = 10;

        float moveSpeed = movement.moveSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            movement.GetRb().velocity = new Vector2(-moveSpeed, movement.GetRb().velocity.y);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.GetRb().velocity = new Vector2(moveSpeed, movement.GetRb().velocity.y);
        }
        else
        {
            float retainedSpeed = dashDirection.x * (moveSpeed * 0.5f);
            movement.GetRb().velocity = new Vector2(retainedSpeed, movement.GetRb().velocity.y);
        }
    }
}
