using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Enrage : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossHealth>().isVulnerable = false;
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossHealth>().isVulnerable = true;
    }
}
