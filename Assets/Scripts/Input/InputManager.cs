using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public InputConfig config;
    private Dictionary<KeyCode, IMovementCommand> movementCommandMap;
    private Dictionary<KeyCode, IAttackCommand> attackCommandMap;
    private IMovementCommand noInput;
    private readonly IMovementCommand hit;

    public InputManager(InputConfig config)
    {
        this.config = config;

        movementCommandMap = new Dictionary<KeyCode, IMovementCommand>();
        attackCommandMap = new Dictionary<KeyCode, IAttackCommand>();

        movementCommandMap[config.moveLeft] = new MoveLeftCommand();
        movementCommandMap[config.moveRight] = new MoveRightCommand();
        movementCommandMap[config.jump] = new JumpCommand();
        movementCommandMap[config.crouch] = new CrouchCommand();
        movementCommandMap[config.dash] = new DashCommand();

        attackCommandMap[config.punch] = new PunchCommand();
        attackCommandMap[config.kick] = new KickCommand();
        attackCommandMap[config.slash] = new SlashCommand();

        hit = new HitCommand();
        noInput = new IdleCommand();
    }

    // Movement Inputs, some actions have a higher priority and will be started over others
    public void ManageMovementInputs(MovementStateManager movement)
    {
        if (!movement.AllowInput)
        {
            return;
        }

        if (Input.GetKeyDown(config.dash))
        {
            movementCommandMap[config.dash].Execute(movement);
            return;
        }

        if (Input.GetKeyDown(config.jump))
        {
            movementCommandMap[config.jump].Execute(movement);
            return;
        }

        if (Input.GetKey(config.crouch))
        {
            movementCommandMap[config.crouch].Execute(movement);
            return;
        }

        if (Input.GetKey(config.moveLeft))
        {
            movementCommandMap[config.moveLeft].Execute(movement);
            return;
        }

        if (Input.GetKey(config.moveRight))
        {
            movementCommandMap[config.moveRight].Execute(movement);
            return;
        }

        noInput.Execute(movement);
    }

    // Attack inputs, no attack has priority over another so the order of starting does not matter
    public void ManageAttackInputs(AttackStateManager attack)
    {
        if (attack.isAttacking)
        {
            return;
        }
        
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
