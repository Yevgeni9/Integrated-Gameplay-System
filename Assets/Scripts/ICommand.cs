using UnityEngine;

public interface ICommand
{
    void Execute(MovementStateManager movement);
}

public class MoveLeftCommand : ICommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.leftState);
    }
}

public class MoveRightCommand : ICommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.rightState);
    }
}

public class CrouchCommand : ICommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.crouchState);
    }
}

public class DashCommand : ICommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.dashState);
    }
}

public class JumpCommand : ICommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.jumpState);
    }
}

public class IdleCommand : ICommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.idleState);
    }
}

