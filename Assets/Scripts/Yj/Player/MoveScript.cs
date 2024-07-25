using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveScript : MonoBehaviour
{
    GameObject model;
    float moveSpeed;
    float rotSpeed;

    public void SetInitial(GameObject _model, float _moveSpeed, float _rotSpeed)
    {
        model = _model;
        moveSpeed = _moveSpeed;
        rotSpeed = _rotSpeed;
    }

 
    public void Move(float h, float v)
    {
        transform.Translate(h * moveSpeed * Time.deltaTime, 0.0f,
                         v * moveSpeed * Time.deltaTime);

        Vector3 moveDirection = new Vector3(h, 0f, v).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        model.transform.rotation = Quaternion.RotateTowards(model.transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }
}