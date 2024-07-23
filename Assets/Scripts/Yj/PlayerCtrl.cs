using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Globalization;
using System.Runtime.InteropServices;
public class PlayerCtrl : NetworkBehaviour
{
    public float moveSpeed;

    [SerializeField]
    private GameObject model;

    [SerializeField]
    private GameObject handGrip_L, handGrip_R;
    [SerializeField]
    private GameObject handOpen_L, handOpen_R;
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private GameObject cleaver;

    private Animator animator;


    enum State
    {
        Choping,
        Death,
        Idle,
        Holding,
        HoldNWalk,
        Wash
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!IsOwner)
        {
            /*return;*/
        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         /*  if(!IsOwner)
        {
            return;
        }*/
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 hv = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(h * moveSpeed * Time.deltaTime, 0.0f,
                         v * moveSpeed * Time.deltaTime);

        if (h != 0 || v != 0)
        {
            Vector3 dir = new Vector3(h, 0, v).normalized;
            model.transform.eulerAngles = new Vector3(0, Mathf.Atan2(dir.x, dir.z) * Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg, 0);
        }


    }

    public void Grab() { animator.SetTrigger("Grab"); }
    public void Release() { animator.SetTrigger("Release"); }

    public void Chop() { animator.SetTrigger("Chop"); }

   


}
