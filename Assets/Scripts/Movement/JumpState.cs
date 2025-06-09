using UnityEngine;

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
