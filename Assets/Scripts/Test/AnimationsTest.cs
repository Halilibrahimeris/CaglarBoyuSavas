using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsTest : MonoBehaviour
{
    [SerializeField] Animator anim;

    [SerializeField] bool AttackTrigger;
    [SerializeField] bool Walk;

    private void Update()
    {
        if (AttackTrigger)
        {
            anim.SetTrigger("Attack");
            Walk = false;
            AttackTrigger = false;
        }
        if (Walk)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
