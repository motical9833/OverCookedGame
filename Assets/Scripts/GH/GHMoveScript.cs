using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngineInternal;

public class GHMoveScript : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float rotSpeed = 5.0f;
    Vector3 move;
    bool isMove = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isMove)
            return;

        this.transform.Translate(0.0f, 0.0f, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        float rotationAmount = Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0.0f, rotationAmount, 0.0f);

        this.transform.rotation *= rotation;
    }


    public void IsMove(bool value)
    {
        isMove = value;
    }
}