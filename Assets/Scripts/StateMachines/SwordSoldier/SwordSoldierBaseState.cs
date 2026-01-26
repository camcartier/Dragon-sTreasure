using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SwordSoldierBaseState : State
{
    protected SwordSoldierStateMachine stateMachine;

    public SwordSoldierBaseState(SwordSoldierStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
