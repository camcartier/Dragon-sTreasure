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

    public IEnumerator timeBeforeIsFiringFalse()
    {
        yield return new WaitForSecondsRealtime(1);
        new PlayerMainState(playerStateMachine).isFiring = true;
    }

    public IEnumerator countingDashReload()
    {
        yield return new WaitForSecondsRealtime(3);
        playerStateMachine.canDash = true;
    }

    public IEnumerator countingFireballReload()
    {
        yield return new WaitForSecondsRealtime(7);
        playerStateMachine.canFireball = true;
    }


    public IEnumerator UnlimitedManaDuration()
    {

        yield return new WaitForSecondsRealtime(5);
        playerStateMachine.GetComponentInParent<PlayerStateMachine>().hasInfiniteMana = false;
        Debug.Log("unlimited mana finished");
    }
}
