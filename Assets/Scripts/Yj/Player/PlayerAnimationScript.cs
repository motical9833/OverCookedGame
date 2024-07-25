using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enummrous;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator animator;

    public void SetAnimator(Animator _animator)
    {
        animator = _animator;
    }

    public void TriggerAnimation(PlayerState _pState)
    {
        switch(_pState)
        {
            case PlayerState.Idle:
                animator.SetTrigger("Idle");
                return;
            case PlayerState.Walk:
                animator.SetTrigger("Walk");
                return;
            case PlayerState.Hold:
                animator.SetTrigger("Hold");
                return;
            case PlayerState.HoldWalk:
                animator.SetTrigger("HoldWalk");
                return;
        }
       
        Debug.LogError("���޵� �ִϸ��̼� Ʈ������ �̸��� �ùٸ��� �ʽ��ϴ�");
    }
}
