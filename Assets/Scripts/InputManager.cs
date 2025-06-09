using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private Dictionary<KeyCode, ICommand> keyCommandMap;
    private ICommand noInput;

    public InputManager()
    {
        keyCommandMap = new Dictionary<KeyCode, ICommand>
        {
            { KeyCode.A, new MoveLeftCommand() },
            { KeyCode.D, new MoveRightCommand() },
            { KeyCode.W, new JumpCommand() },
            { KeyCode.S, new CrouchCommand() },
            { KeyCode.LeftShift, new DashCommand() }
        };

        noInput = new IdleCommand();
    }

    public void ManageInput(MovementStateManager movement)
    {
        if (!movement.AllowInput)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            keyCommandMap[KeyCode.LeftShift].Execute(movement);
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            keyCommandMap[KeyCode.W].Execute(movement);
            return;
        }

        if (Input.GetKey(KeyCode.S))
        {
            keyCommandMap[KeyCode.S].Execute(movement);
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            keyCommandMap[KeyCode.A].Execute(movement);
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            keyCommandMap[KeyCode.D].Execute(movement);
            return;
        }

        noInput.Execute(movement);
    }
}
