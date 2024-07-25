using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Globalization;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
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
    #endregion
    [SerializeField]
    private BoxCollider frontCol;

    public enum State
    {
        Choping,
        Death,
        Idle,
        Holding,
        Walk,
        HoldNWalk,
        Wash
    }
    public State state;

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
    }

    // Update is called once per frame
    void Update()
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
            pActionScript.BarAction();
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
            if (state == State.Idle)
            {
                state = State.Walk;
            }
            moveScript.Move(h,v);
            pAnimScript.TriggerAnimation("Walk");
        }
        else
        {
            state = State.Idle;
            pAnimScript.TriggerAnimation("Idle");
        }
    }
}
