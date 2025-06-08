using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    private Dictionary<KeyCode, ICommand> keyCommandMap;

    public InputManager()
    {
        keyCommandMap = new Dictionary<KeyCode, ICommand>
        {
            { KeyCode.A, new MoveLeftCommand() },
            { KeyCode.D, new MoveRightCommand() },
            { KeyCode.W, new JumpCommand() }
        };
    }

    public void ManageInput(MovementStateManager movement)
    {
        foreach (var entry in keyCommandMap)
        {
            if (Input.GetKeyDown(entry.Key))
            {
                entry.Value.Execute(movement);
            }
        }
    }
}
