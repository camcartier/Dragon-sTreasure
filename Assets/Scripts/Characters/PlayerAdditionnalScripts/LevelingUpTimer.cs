using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingUpTimer : MonoBehaviour
{
    [SerializeField] PlayerStateMachine playerStateMachine;

    public IEnumerator countingLevelUp()
    {
        yield return new WaitForSecondsRealtime(2);
        playerStateMachine.SwitchState(new PlayerMainState(playerStateMachine));

    }
}
