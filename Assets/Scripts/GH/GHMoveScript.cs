using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GHMoveScript : MonoBehaviour
{

    public float speed = 5.0f;
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

        this.transform.Translate
            (
            Input.GetAxis("Horizontal") * speed * Time.deltaTime,
            0.0f,
            Input.GetAxis("Vertical") * speed * Time.deltaTime
            );
    }


    public void IsMove(bool value)
    {
        isMove = value;
    }
}