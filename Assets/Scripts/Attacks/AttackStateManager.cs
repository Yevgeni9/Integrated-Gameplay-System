using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AttackStateManager
{
    public Player player;
    private AttackBaseState currentState;
    public bool isAttacking;

    public PunchState punchState = new PunchState();
    public KickState kickState = new KickState();
    public SlashState slashState = new SlashState();
    public NoAttackState noAttackState = new NoAttackState();

    public bool AllowInput { get; private set; } = true;

    public AttackStateManager(Player player)
    {
        this.player = player;
    }

    public void Start()
    {
        currentState = noAttackState;
        currentState.EnterState(this);
    }

    public void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(AttackBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    public void StartAttack()
    {
        isAttacking = true;
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}
