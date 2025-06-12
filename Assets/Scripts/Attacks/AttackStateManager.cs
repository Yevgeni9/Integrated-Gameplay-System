using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateManager
{
    public AttackBaseState currentState;
    public GameSettingsConfig config;
    public Player player;
    private MonoBehaviour coroutineStarter;

    public bool isAttacking;

    public event Action OnAttackStart;
    public event Action OnAttackEnd;

    public PunchState punchState = new PunchState();
    public KickState kickState = new KickState();
    public SlashState slashState = new SlashState();
    public NoAttackState noAttackState = new NoAttackState();

    public AttackStateManager(Player player, GameSettingsConfig config, MonoBehaviour coroutineStarter)
    {
        Start();
        this.player = player;
        this.config = config;
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
    }

    public void EndAttack()
    {
        isAttacking = false;
        OnAttackEnd?.Invoke();
    }

    public void StartCoroutine(IEnumerator routine)
    {
        coroutineStarter.StartCoroutine(routine);
    }
}
