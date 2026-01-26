using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSoldierStateMachine : StateMachine
{
    void Start()
    {
        SwitchState(new SwordSoldierMainState(this));
    }
}
