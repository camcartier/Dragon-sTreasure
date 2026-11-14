using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class PlayerCoroutinesScript : MonoBehaviour
{
    [SerializeField] PlayerStateMachine playerStateMachine;
    [SerializeField] PlayerData playerData;

    private bool dashCountdownStarted;
    private bool fireballCountdownStarted;
    private bool repulseCountdownStarted;

    public float dashCooldownCounter;
    public float fireballCooldownCounter;
    public float repulseCooldownCounter;

    [SerializeField] GameObject dashFillImage;
    [SerializeField] GameObject fireballFillImage;
    [SerializeField] GameObject repulseFillImage;

    private void Update()
    {
        if (dashCountdownStarted)
        {
            dashFillImage.SetActive(true);
            dashCooldownCounter += Time.deltaTime;
            if (dashCooldownCounter > playerStateMachine.PlayerData.dashDelay)
            {
                dashCountdownStarted = false;
                dashCooldownCounter = 0f;
                dashFillImage.SetActive(false);
            }
        }
        if (fireballCountdownStarted)
        {
            fireballFillImage.SetActive(true);
            fireballCooldownCounter += Time.deltaTime;
            if (fireballCooldownCounter > playerStateMachine.PlayerData.fireballDelay)
            {
                fireballCountdownStarted = false;
                fireballCooldownCounter = 0f;
                fireballFillImage.SetActive(false);
            }
        }
        if (repulseCountdownStarted) 
        {
            repulseFillImage.SetActive(true);
            repulseCooldownCounter += Time.deltaTime;
            if (repulseCooldownCounter > playerStateMachine.PlayerData.repulseDelay)
            {
                repulseCountdownStarted = false;
                repulseCooldownCounter = 0f;
                repulseFillImage.SetActive(false);
            }
        }
    }

    public IEnumerator countingInvulnerability()
    {
        yield return new WaitForSeconds(playerData.invulnerabilityDuration);
        playerStateMachine.isInvulnerable = false;
    }

    public IEnumerator invulnerableBlinkingRed()
    {
        float totalElapsedTime = 0f;
        while (totalElapsedTime < playerData.invulnerabilityDuration) 
        {

            yield return new WaitForSeconds(0.25f);
            playerStateMachine.MainSpriteRenderer.color = Color.red;
            totalElapsedTime += 0.25f;
            yield return new WaitForSeconds(0.25f);
            playerStateMachine.MainSpriteRenderer.color = Color.white;
            totalElapsedTime += 0.25f;
        }
        

    }

    /*
    //le temps pris par l'animation d'evolution
    //a switcher depuis le script levelingUpTimer
    public IEnumerator countingLevelUp()
    {
        yield return new WaitForSecondsRealtime(2);
        playerStateMachine.SwitchState(new PlayerMainState(playerStateMachine));

    }*/

    /*
    public IEnumerator timeBeforeIsFiringFalse()
    {
        yield return new WaitForSecondsRealtime(1);
        new PlayerMainState(playerStateMachine).isFiring = true;
    }*/

    public IEnumerator countingDashReload()
    {
        dashCountdownStarted = true;
        yield return new WaitForSecondsRealtime(playerStateMachine.PlayerData.dashDelay);
        playerStateMachine.canDash = true;
    }

    public IEnumerator countingFireballReload()
    {
        fireballCountdownStarted = true;
        yield return new WaitForSecondsRealtime(playerStateMachine.PlayerData.fireballDelay);
        playerStateMachine.canFireball = true;
    }

    public IEnumerator countingRepulseReload()
    {
        repulseCountdownStarted = true;
        yield return new WaitForSecondsRealtime(playerStateMachine.PlayerData.repulseDelay);
        playerStateMachine.canRepulse = true;
    }


    /*
    public IEnumerator UnlimitedManaDuration()
    {

        yield return new WaitForSecondsRealtime(5);
        playerStateMachine.GetComponentInParent<PlayerStateMachine>().hasInfiniteMana = false;
        Debug.Log("unlimited mana finished");
    }
    */
}
