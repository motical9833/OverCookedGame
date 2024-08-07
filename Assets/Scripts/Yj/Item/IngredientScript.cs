using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientScript : GrabAbleObjScript
{
    bool isChopped = false;
    float cutting_time;
    Animator animator;

    public override void Initialize()
    {
        base.Initialize();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Chop();
        }
    }

    public void Chop()
    {

        Debug.Log("���Ĺ� �丮�� ��");
    }

    public bool GetIsChopped()
    {
        return isChopped;
    }
}
