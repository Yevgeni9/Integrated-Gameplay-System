using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AttackStateManager
{
    public Player player;
    private MonoBehaviour coroutineStarter;
    public AttackBaseState currentState;
    public bool isAttacking;

    public PunchState punchState = new PunchState();
    public KickState kickState = new KickState();
    public SlashState slashState = new SlashState();
    public NoAttackState noAttackState = new NoAttackState();

    public event Action OnAttackStart;
    public event Action OnAttackEnd;

    public bool AllowInput { get; private set; } = true;

    public AttackStateManager(Player player, MonoBehaviour coroutineStarter)
    {
        Start();
        this.player = player;
        this.coroutineStarter = coroutineStarter;
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
        OnAttackStart?.Invoke();
        AllowInput = false;
    }

    public void EndAttack()
    {
        isAttacking = false;
        OnAttackEnd?.Invoke();
        AllowInput = true;
    }

    public void SetAllowInput(bool allowed)
    {
        AllowInput = allowed;
    }

    public void StartCoroutine(IEnumerator routine)
    {
        coroutineStarter.StartCoroutine(routine);
    }
}
