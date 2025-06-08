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

public class JumpCommand : ICommand
{
    public void Execute(MovementStateManager movement)
    {
        movement.SwitchState(movement.jumpState);
    }
}

