using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Globalization;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using Enummrous;
using System.Security.Cryptography;
using UnityEngine.Playables;
public class PlayerCtrlScript : NetworkBehaviour
{
    [SerializeField]
    private GameObject model;

    PlayerAnimationScript pAnimScript;
    ActionScript pActionScript;

    MoveScript moveScript;
    public float moveSpeed;

    [Tooltip("ĳ������ ȸ�� �ӵ�")]
    [Range(500, 1000)]
    public float rotSpeed;

    #region"�μ�ǰ"
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

    Enummrous.GrabState pGrabState;

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
        //������ �ݶ��̴��� üũ�ϰ� ������ �´� �±׸� �Ѿ��
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            pActionScript.CtrlAction();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if( pActionScript.BarAction() == true)
            {
                if (pGrabState == GrabState.Release)
                {
                    switch( pAnimScript.GetAnimState())
                    {
                        case PlayerAnimState.Idle:
                            pAnimScript.TriggerAnimation(PlayerAnimState.Hold);
                            break;
                        case PlayerAnimState.Walk:
                            pAnimScript.TriggerAnimation(PlayerAnimState.HoldWalk);
                            break;
                    }
                    pGrabState = GrabState.Grab;
                }
                else if(pGrabState == GrabState.Grab)
                {
                    switch (pAnimScript.GetAnimState())
                    {
                        case PlayerAnimState.Hold:
                            pAnimScript.TriggerAnimation(PlayerAnimState.Idle);
                            break;
                        case PlayerAnimState.HoldWalk:
                            pAnimScript.TriggerAnimation(PlayerAnimState.Walk);
                            break;
                    }
                    pGrabState = GrabState.Release;
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
            switch (pAnimScript.GetAnimState())
            {
                case PlayerAnimState.Idle:
                    pAnimScript.TriggerAnimation(PlayerAnimState.Walk);
                    break;
                case PlayerAnimState.Hold:
                    pAnimScript.TriggerAnimation(PlayerAnimState.HoldWalk);
                    break;
                case PlayerAnimState.Walk:
                    pAnimScript.TriggerAnimation(PlayerAnimState.Walk);
                    break;
                case PlayerAnimState.HoldWalk:
                    pAnimScript.TriggerAnimation(PlayerAnimState.HoldWalk);
                    break;
            }
        }
        else
        {
            switch (pAnimScript.GetAnimState())
            {
                case PlayerAnimState.HoldWalk:
                    pAnimScript.TriggerAnimation(PlayerAnimState.Hold);
                    break;
                case PlayerAnimState.Hold:
                    pAnimScript.TriggerAnimation(PlayerAnimState.Hold);
                    break;
                case PlayerAnimState.Walk:
                    pAnimScript.TriggerAnimation(PlayerAnimState.Idle);
                    break;
            }
        }
    }
}
