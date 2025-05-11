using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoroutinesScript : MonoBehaviour
{
    [SerializeField] PlayerStateMachine playerStateMachine;
    [SerializeField] PlayerData playerData;
    
    public IEnumerator countingInvulnerability()
    {
        yield return new WaitForSeconds(playerData.invulnerabilityDuration);
        playerStateMachine.isInvulnerable = false;
    }

    //le temps pris par l'animation d'evolution
    //a switcher depuis le script levelingUpTimer
    public IEnumerator countingLevelUp()
    {
        yield return new WaitForSecondsRealtime(2);
        playerStateMachine.SwitchState(new PlayerMainState(playerStateMachine));

    }
}
