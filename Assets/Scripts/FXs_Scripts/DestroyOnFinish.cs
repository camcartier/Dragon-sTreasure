using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFinish : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.normalizedTime >= 1)
        {
            Destroy(gameObject);
        }
    }
}
