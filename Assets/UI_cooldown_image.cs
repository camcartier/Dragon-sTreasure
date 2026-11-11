using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_cooldown_image : MonoBehaviour
{
    [SerializeField] Image dashFillImage;
    [SerializeField] Image fireballFillImage;
    [SerializeField] Image repulseFillImage;
    private PlayerStateMachine playerStateMachine;

    private float cooldownTimer;
    private bool cooldownOver;

    private bool dashIsEnabled;

    // Start is called before the first frame update
    void Start()
    {
        playerStateMachine = GameObject.Find("Player").GetComponent<PlayerStateMachine>();



        dashFillImage.fillAmount = 0f;
        fireballFillImage.fillAmount = 0f;
        repulseFillImage.fillAmount = 0f;
        //dashFillImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float dashcooldown = playerStateMachine.PlayerData.dashDelay;
        float fireballcooldown = playerStateMachine.PlayerData.fireballDelay;
        float repulsecooldown = playerStateMachine.PlayerData.repulseDelay;
        


        dashFillImage.fillAmount = Mathf.Clamp01(
            1f - (playerStateMachine.dashCooldownCounter / dashcooldown)
        );

        fireballFillImage.fillAmount = Mathf.Clamp01(
        1f - (playerStateMachine.fireballCooldownCounter / fireballcooldown)
        );

        repulseFillImage.fillAmount = Mathf.Clamp01(
        1f - (playerStateMachine.repulseCooldownCounter / repulsecooldown)
        );
    }
}
