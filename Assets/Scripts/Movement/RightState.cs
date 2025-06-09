using UnityEngine;

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
