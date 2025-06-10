using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBaseState
{
    public abstract void EnterState(AttackStateManager attack);

    public abstract void UpdateState(AttackStateManager attack);

    public abstract void ExitState(AttackStateManager attack);
}

public class PunchState : AttackBaseState
{
    public override void EnterState(AttackStateManager attack)
    {
        Debug.Log("Entered Punch");
    }

    public override void UpdateState(AttackStateManager attack)
    {

    }

    public override void ExitState(AttackStateManager attack)
    {

    }
}

public class KickState : AttackBaseState
{
    public override void EnterState(AttackStateManager attack)
    {
        Debug.Log("Entered Kick");
    }

    public override void UpdateState(AttackStateManager attack)
    {

    }

    public override void ExitState(AttackStateManager attack)
    {

    }
}

public class SlashState : AttackBaseState
{
    public override void EnterState(AttackStateManager attack)
    {
        Debug.Log("Entered Slash");
    }

    public override void UpdateState(AttackStateManager attack)
    {

    }

    public override void ExitState(AttackStateManager attack)
    {

    }
}
