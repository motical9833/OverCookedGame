using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientScript : GrabAbleObjScript
{
    bool isChopped = false;

    float cutting_time;


    public override void Initialize()
    {
        base.Initialize();
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
