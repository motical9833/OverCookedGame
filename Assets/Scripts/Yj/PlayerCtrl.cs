using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System.Globalization;
public class PlayerCtrl : NetworkBehaviour
{
    public float mMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsOwner)
        {
            return;
        }
        Move();
    }

    private void Move()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left.normalized * mMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward.normalized * mMoveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back.normalized * mMoveSpeed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right.normalized * mMoveSpeed * Time.deltaTime);
        }
   
    }
}
