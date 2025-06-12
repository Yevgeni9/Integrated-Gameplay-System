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
    public override void EnterState(MovementStateManager movement) { }
    public override void UpdateState(MovementStateManager movement) { }
    public override void ExitState(MovementStateManager movement) { }
}

public class LeftState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is going left");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        movement.transform.Translate(Vector3.left * movement.config.moveSpeed * Time.deltaTime);
    }

    public override void ExitState(MovementStateManager movement) { }
}

public class RightState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is going right");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        movement.transform.Translate(Vector3.right * movement.config.moveSpeed * Time.deltaTime);
    }

    public override void ExitState(MovementStateManager movement) { }
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

        movement.GetRb().AddForce(Vector2.up * movement.config.jumpForce);
        movement.isGrounded = false;
    }

    public override void UpdateState(MovementStateManager movement) { }
    public override void ExitState(MovementStateManager movement) { }
}

public class CrouchState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("is Crouched");
        movement.transform.localScale = new Vector2(movement.transform.localScale.x, movement.config.crouchScale); // Ideally I would change a sprite here or start an animation, but for the prototype im just reducing the cube size
    }

    public override void UpdateState(MovementStateManager movement) { }

    public override void ExitState(MovementStateManager movement)
    {
        movement.transform.localScale = new Vector2(movement.transform.localScale.x, movement.config.defaultHeightScale); // Reset to normal size
    }
}

public class DashState : MovementBaseState
{
    private float elapsedTime = 0f;
    private Vector2 dashDirection;

    public override void EnterState(MovementStateManager movement)
    {
        movement.SetAllowInput(false);

        elapsedTime = 0f;

        var config = movement.player.inputManager.config;

        float dir = Input.GetKey(config.moveRight) ? 1 :
                    Input.GetKey(config.moveLeft) ? -1 :
                    movement.GetRb().velocity.x >= 0 ? 1 : -1;

        dashDirection = new Vector2(dir, 0).normalized;
        movement.GetRb().velocity = dashDirection * movement.config.dashSpeed;
        movement.GetRb().gravityScale = 0;
    }

    public override void UpdateState(MovementStateManager movement)
    {
        elapsedTime += Time.deltaTime;

        movement.GetRb().velocity = dashDirection * movement.config.dashSpeed;

        if (elapsedTime >= movement.config.dashDuration)
        {
            movement.SwitchState(movement.idleState);
        }
    }

    public override void ExitState(MovementStateManager movement)
    {
        var config = movement.player.inputManager.config;
        float moveSpeed = movement.config.moveSpeed;

        movement.SetAllowInput(true);
        movement.GetRb().gravityScale = movement.config.gravityScale;

        if (Input.GetKey(config.moveLeft))
        {
            movement.GetRb().velocity = new Vector2(-movement.config.moveSpeed, movement.GetRb().velocity.y);
        }
        else if (Input.GetKey(config.moveRight))
        {
            movement.GetRb().velocity = new Vector2(movement.config.moveSpeed, movement.GetRb().velocity.y);
        }
        else
        {
            float retainedSpeed = dashDirection.x * (movement.config.moveSpeed * 0.5f); // Not holding an input will reduce the velocity
            movement.GetRb().velocity = new Vector2(retainedSpeed, movement.GetRb().velocity.y);
        }
    }
}

// Hit state will knock the player back from the attacker
public class HitState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        Debug.Log("Hit!");

        Vector2 direction = (movement.transform.position - movement.player.enemy.transform.position).normalized;
        Vector2 knockback = new Vector2(direction.x * movement.config.horizontalKnockback, movement.config.verticalKnockback);

        movement.player.rb.velocity = Vector2.zero;
        movement.player.rb.AddForce(knockback, ForceMode2D.Impulse);
    }

    public override void UpdateState(MovementStateManager movement) { }
    public override void ExitState(MovementStateManager movement) { }
}
