using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientScript : GrabAbleObjScript
{
    bool isChopped = false;
    float cutting_time;

    Animator animator;
    public string controllerPath = "AnimatorController";  // Resources 폴더 안의 경로 (확장자 제외)

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

        Debug.Log("음식물 썰리는 중");
    }

    public bool GetIsChopped()
    {
        return isChopped;
    }
}
