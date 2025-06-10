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
        attack.StartAttack();
        attack.player.punchHitbox.SetActive(true);
        attack.player.StartCoroutine(StartAttack(attack, 1f));
    }

    public override void UpdateState(AttackStateManager attack)
    {

    }

    public override void ExitState(AttackStateManager attack)
    {
        Debug.Log("Exited Punch");
    }

    private IEnumerator StartAttack(AttackStateManager attack, float delay)
    {
        yield return new WaitForSeconds(delay);
        attack.player.punchHitbox.SetActive(false);
        attack.EndAttack();
        attack.SwitchState(attack.noAttackState);
    }
}

public class KickState : AttackBaseState
{
    public override void EnterState(AttackStateManager attack)
    {
        Debug.Log("Entered Kick");
        attack.StartAttack();
        attack.player.kickHitbox.SetActive(true);
        attack.player.StartCoroutine(StartAttack(attack, 1f));
    }

    public override void UpdateState(AttackStateManager attack)
    {

    }

    public override void ExitState(AttackStateManager attack)
    {
        Debug.Log("Exited Kick");
    }

    private IEnumerator StartAttack(AttackStateManager attack, float delay)
    {
        yield return new WaitForSeconds(delay);
        attack.player.kickHitbox.SetActive(false);
        attack.EndAttack();
        attack.SwitchState(attack.noAttackState);
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

public class NoAttackState : AttackBaseState
{
    public override void EnterState(AttackStateManager attack)
    {
        Debug.Log("Not attacking");
    }

    public override void UpdateState(AttackStateManager attack)
    {

    }

    public override void ExitState(AttackStateManager attack)
    {

    }
}
