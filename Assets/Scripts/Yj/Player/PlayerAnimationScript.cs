using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enummrous;
using UnityEditor;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator animator;
    Enummrous.PlayerAnimState pAnimState;

    private void Start()
    {
        pAnimState = PlayerAnimState.Idle;
    }

    private void Update()
    {
        switch (pAnimState)
        {
            case PlayerAnimState.Idle:
                animator.SetTrigger("Idle");
                break;
            case PlayerAnimState.Walk:
                animator.SetTrigger("Walk");
                break;
            case PlayerAnimState.Hold:
                animator.SetTrigger("Hold");
                break;
            case PlayerAnimState.HoldWalk:
                animator.SetTrigger("HoldWalk");
                break;
            case PlayerAnimState.Chop:
                animator.SetTrigger("Chop");
                break;
        }
    }
    public void SetAnimator(Animator _animator)
    {
        animator = _animator;
    }

    public void TriggerAnimation(PlayerAnimState _pState)
    {
        pAnimState = _pState;
    }

    public Enummrous.PlayerAnimState GetAnimState()
    {
        return pAnimState;
    }

    public bool IsAnimationEnd(string _animName)
    {
        bool isAimationFinished = false;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // ���̾� 0 ���

        if (stateInfo.IsName(_animName))
        {
            // �ִϸ��̼��� ����Ǿ����� Ȯ�� (normalizedTime�� 1 �̻��̸� ����� ��)
            if (stateInfo.normalizedTime >= 1.0f && !isAimationFinished)
            {
                isAimationFinished = true;
            }
        }
        return isAimationFinished;
    }
}
