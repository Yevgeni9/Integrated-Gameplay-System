using UnityEngine;

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
