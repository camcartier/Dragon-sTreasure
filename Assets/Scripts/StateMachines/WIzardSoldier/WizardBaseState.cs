using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WizardBaseState : State
{
    protected WizardStateMachine stateMachine;

    public WizardBaseState(WizardStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
