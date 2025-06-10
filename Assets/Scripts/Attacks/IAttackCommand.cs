using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackCommand
{
    void Execute(AttackStateManager attack);
}

public class PunchCommand : IAttackCommand
{
    public void Execute(AttackStateManager attack)
    {
        attack.SwitchState(attack.punchState);
    }
}

public class KickCommand : IAttackCommand
{
    public void Execute(AttackStateManager attack)
    {
        attack.SwitchState(attack.kickState);
    }
}

public class SlashCommand : IAttackCommand
{
    public void Execute(AttackStateManager attack)
    {
        attack.SwitchState(attack.slashState);
    }
}