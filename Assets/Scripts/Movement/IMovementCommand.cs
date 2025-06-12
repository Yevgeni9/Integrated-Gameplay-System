using UnityEngine;

public interface IMovementCommand
{
    void Execute(MovementStateManager movement);
}

public class MoveLeftCommand : IMovementCommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.leftState);
    }
}

public class MoveRightCommand : IMovementCommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.rightState);
    }
}

public class CrouchCommand : IMovementCommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.crouchState);
    }
}

public class DashCommand : IMovementCommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.dashState);
    }
}

public class JumpCommand : IMovementCommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.jumpState);
    }
}

public class IdleCommand : IMovementCommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.idleState);
    }
}

public class HitCommand : IMovementCommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.hitState);
    }
}
