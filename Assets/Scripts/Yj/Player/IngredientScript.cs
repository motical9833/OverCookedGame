using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientScript : MonoBehaviour
{
    SphereCollider col;
    Rigidbody rb;

    bool isChopped = false;

    public void Initialize()
    {
        col = GetComponent<SphereCollider>();
        rb = transform.GetComponent<Rigidbody>();
    }

    public void Grabbed()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        col.isTrigger = true;
        transform.localRotation = Quaternion.identity;
    }

    public void Release()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        col.isTrigger = false;
    }

    public void Chop()
    {
        
    }
}
