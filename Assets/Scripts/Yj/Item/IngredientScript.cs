using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientScript : GrabAbleObjScript
{
    bool isChopped = false;
    float cutting_time;

    Animator animator;
    public string controllerPath = "AnimatorController";  // Resources ���� ���� ��� (Ȯ���� ����)

    public override void Initialize()
    {
        base.Initialize();
        animator = transform.AddComponent<Animator>();
        string name = gameObject.name;
        string path = name.Replace("(Clone)", "");
        RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>(controllerPath + "/" + path);
        animator.runtimeAnimatorController = controller;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Chop();
        }
    }

    public void Gather()
    {
        if (!isChopped)
            return;



    }

    public void Drop()
    {

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
