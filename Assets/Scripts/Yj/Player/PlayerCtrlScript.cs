using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Globalization;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using Enummrous;
public class PlayerCtrlScript : NetworkBehaviour
{
    [SerializeField]
    private GameObject model;

    PlayerAnimationScript pAnimScript;
    ActionScript pActionScript;

    MoveScript moveScript;
    public float moveSpeed;

    [Tooltip("캐릭터의 회전 속도")]
    [Range(500, 1000)]
    public float rotSpeed;

    #region"부속품"
    [SerializeField]
    private GameObject handGrip_L, handGrip_R;
    [SerializeField]
    private GameObject handOpen_L, handOpen_R;
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private GameObject cleaver;

    [SerializeField]
    private BoxCollider frontCol;

    [SerializeField]
    private GameObject hand;

    #endregion

    Enummrous.PlayerState pState;

    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner)
        {
            /*return;*/
        }
        pAnimScript = GetComponent<PlayerAnimationScript>();
        pAnimScript.SetAnimator(model.GetComponent<Animator>());

        moveScript = transform.GetComponent<MoveScript>();
        moveScript.SetInitial(model,moveSpeed, rotSpeed);

        pActionScript = transform.GetComponent<ActionScript>();
        pActionScript.InitialSet(frontCol,hand);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!IsOwner)
        {
           //return;
        }
        //정면의 콜라이더를 체크하고 각각에 맞는 태그면 넘어가자
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            pActionScript.CtrlAction();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if( pActionScript.BarAction() == (PlayerState.Hold, true))
            {
                if (pState == PlayerState.Idle)
                {
                    pAnimScript.TriggerAnimation(PlayerState.Hold);
                    pState = PlayerState.Hold;
                }
                if (pState == PlayerState.Walk)
                {
                    pState = PlayerState.HoldWalk;
                    pAnimScript.TriggerAnimation(PlayerState.HoldWalk);
                }
            }
        }
    }


    private void FixedUpdate()
    {
        /*  if(!IsOwner)
        {
            return;
        }*/
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0 || v != 0)
        {
            moveScript.Move(h, v);
            switch (pState)
            {
                case PlayerState.Idle:
                    pState = PlayerState.Walk;
                    pAnimScript.TriggerAnimation(PlayerState.Walk);
                    break;
                case PlayerState.Hold:
                    pState = PlayerState.HoldWalk;
                    pAnimScript.TriggerAnimation(PlayerState.HoldWalk);
                    break;
                case PlayerState.HoldWalk:
                    pState = PlayerState.HoldWalk;
                    pAnimScript.TriggerAnimation(PlayerState.HoldWalk);
                    break;
            }
        }
        else
        {
            switch (pState)
            {
                case PlayerState.HoldWalk:
                    pState = PlayerState.Hold;
                    pAnimScript.TriggerAnimation(PlayerState.Hold);
                    break;
                case PlayerState.Hold:
                    pState = PlayerState.Hold;
                    pAnimScript.TriggerAnimation(PlayerState.Hold);
                    break;
                case PlayerState.Walk:
                    pState = PlayerState.Idle;
                    pAnimScript.TriggerAnimation(PlayerState.Idle);
                    break;

            }
        }
    }
}
