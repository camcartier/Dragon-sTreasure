using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossYakBaseState : State
{
    protected BossYakStateMachine bossyakstateMachine;

    public BossYakBaseState(BossYakStateMachine stateMachine)
    {
        this.bossyakstateMachine = stateMachine;
    }

}
