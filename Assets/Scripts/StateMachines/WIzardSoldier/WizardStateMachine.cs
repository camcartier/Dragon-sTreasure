using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardStateMachine : StateMachine
{
    void Start()
    {
        SwitchState(new WizardMainState(this));
    }
}
