using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator animator;

    public void SetAnimator(Animator _animator)
    {
        animator = _animator;
    }

    public void TriggerAnimation(string _triggerName)
    {
        switch(_triggerName)
        {
            case "Idle":
                animator.SetTrigger("Idle");
                return;
            case "Walk":
                animator.SetTrigger("Walk");
                return;
        }
       
        Debug.LogError("���޵� �ִϸ��̼� Ʈ������ �̸��� �ùٸ��� �ʽ��ϴ�");
    }
}
