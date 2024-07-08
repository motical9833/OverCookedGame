using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    public float speed = 5.0f;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate
            (
            Input.GetAxis("Horizontal")* speed * Time.deltaTime,
            0.0f,
            Input.GetAxis("Vertical") * speed * Time.deltaTime
            );


    }
}
