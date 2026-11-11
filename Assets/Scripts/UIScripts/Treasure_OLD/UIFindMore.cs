using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFindMore : MonoBehaviour
{

    public float TimeOnScreen;
    public float EndOfAnimationCounter;

    void Start()
    {
        StartCoroutine(fadeInTime(TimeOnScreen));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("StartingTXT_fadeOut"))
        {
            if (EndOfAnimationCounter < gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length)
            {
                EndOfAnimationCounter += Time.deltaTime;
            }
            else { gameObject.SetActive(false); }
        }
    }

    IEnumerator fadeInTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponentInChildren<Animator>().Play("StartingTXT_fadeOut");
    }
}
