using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientScript : GrabAbleObjScript
{
    bool isChopped = false;
    bool isChoppingProgress = false;
    float cutting_time;

    Animator animator;
    public string controllerPath = "AnimatorController";  // Resources 폴더 안의 경로 (확장자 제외)
    float sliceGuage;

    private GameObject wholeObj;
    private GameObject sliceObj;
    bool isFirstSlice = false;

    public override void Initialize()
    {
        base.Initialize();
        SetAnimator();
        wholeObj = transform.GetChild(0).Find("Onion_Mesh").transform.Find("Onion_Whole").gameObject;
        sliceObj = transform.GetChild(0).Find("Onion_Mesh").transform.Find("Onion_Sliced").gameObject;
        sliceObj.SetActive(false);
    }
  
    private void SetAnimator()
    {
        animator = transform.AddComponent<Animator>();
        string name = gameObject.name;
        string path = name.Replace("(Clone)", "");
        RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>(controllerPath + "/" + path);
        animator.runtimeAnimatorController = controller;
    }
    public void Gather()
    {
        if (!isChopped)
            return;
        animator.SetTrigger("Gather");
    }

    public void Drop()
    {
        animator.SetTrigger("Drop");
    }

    public void Chopping()
    {
        if (!isChopped)
        {
            sliceGuage += Time.deltaTime * 33;
            animator.SetFloat("Slice", sliceGuage);
            if (!isFirstSlice && sliceGuage <= 33)
            {
                isFirstSlice = true;
                wholeObj.SetActive(false);
                sliceObj.SetActive(true);
            }
            if (sliceGuage >= 100)
            {
                isChopped = true;
            }
        }
    }

    public bool GetIsChopped()
    {
        return isChopped;
    }
}
