using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AttackStateManager
{
    private AttackBaseState currentState;

    public PunchState punchState = new PunchState();
    public KickState kickState = new KickState();
    public SlashState slashState = new SlashState();

    public bool AllowInput { get; private set; } = true;

    public void Start()
    {
        currentState = punchState;
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
}
