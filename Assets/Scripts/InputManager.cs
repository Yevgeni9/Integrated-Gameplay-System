using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private Dictionary<KeyCode, IMovementCommand> movementCommandMap;
    private Dictionary<KeyCode, IAttackCommand> attackCommandMap;
    private IMovementCommand noInput;

    public InputManager()
    {
        movementCommandMap = new Dictionary<KeyCode, IMovementCommand>
        {
            { KeyCode.A, new MoveLeftCommand() },
            { KeyCode.D, new MoveRightCommand() },
            { KeyCode.W, new JumpCommand() },
            { KeyCode.S, new CrouchCommand() },
            { KeyCode.LeftShift, new DashCommand() }
        };

        attackCommandMap = new Dictionary<KeyCode, IAttackCommand>
        {
            { KeyCode.J, new PunchCommand() },
            { KeyCode.K, new KickCommand() },
            { KeyCode.I, new SlashCommand() }
        };

        noInput = new IdleCommand();
    }

    public void ManageMovementInputs(MovementStateManager movement)
    {
        // Movement inputs, some movement actions have a higher priority like dash and jump
        if (!movement.AllowInput)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementCommandMap[KeyCode.LeftShift].Execute(movement);
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            movementCommandMap[KeyCode.W].Execute(movement);
            return;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementCommandMap[KeyCode.S].Execute(movement);
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementCommandMap[KeyCode.A].Execute(movement);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementCommandMap[KeyCode.D].Execute(movement);
            return;
        }

        noInput.Execute(movement);
    }

    public void ManageAttackInputs(AttackStateManager attack)
    {
        if (attack.isAttacking)
        {
            return;
        }

        // Attack inputs, does not have priority so it can be done in a loop
        foreach (var pair in attackCommandMap)
        {
            if (Input.GetKeyDown(pair.Key))
            {
                pair.Value.Execute(attack);
                return;
            }
        }
    }
}
