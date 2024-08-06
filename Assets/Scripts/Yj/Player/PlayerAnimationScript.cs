using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enummrous;

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
}
