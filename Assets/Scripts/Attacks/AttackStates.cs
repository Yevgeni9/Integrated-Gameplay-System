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
        attack.StartCoroutine(StartAttack(attack, 0.2f));
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
        attack.StartAttack();
        attack.player.punchHitbox.SetActive(true);
        yield return new WaitForSeconds(delay);
        attack.EndAttack();
        attack.player.punchHitbox.SetActive(false);
        attack.SwitchState(attack.noAttackState);
    }
}

public class KickState : AttackBaseState
{
    public override void EnterState(AttackStateManager attack)
    {
        Debug.Log("Entered Kick");
        attack.StartCoroutine(StartAttack(attack, 0.3f));
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
        attack.StartAttack();
        attack.player.kickHitbox.SetActive(true);
        yield return new WaitForSeconds(delay);
        attack.EndAttack();
        attack.player.kickHitbox.SetActive(false);
        attack.SwitchState(attack.noAttackState);
    }
}

public class SlashState : AttackBaseState
{
    public override void EnterState(AttackStateManager attack)
    {
        Debug.Log("Entered Slash");
        attack.StartCoroutine(StartAttack(attack, 0.4f));
    }

    public override void UpdateState(AttackStateManager attack)
    {

    }

    public override void ExitState(AttackStateManager attack)
    {

    }

    private IEnumerator StartAttack(AttackStateManager attack, float delay)
    {
        attack.StartAttack();
        attack.player.slashHitbox.SetActive(true);
        yield return new WaitForSeconds(delay);
        attack.EndAttack();
        attack.player.slashHitbox.SetActive(false);
        attack.SwitchState(attack.noAttackState);
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
