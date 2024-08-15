using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Enummrous;

public class IngredientScript : GrabAbleObjScript
{
    bool isChopped = false;

    Animator animator;
    public string controllerPath = "AnimatorController";  // Resources Æú´õ ¾ÈÀÇ °æ·Î (È®ÀåÀÚ Á¦¿Ü)
    
    float sliceGuage;

    private GameObject wholeObj;
    private GameObject sliceObj;
    bool isFirstSlice = false;

    IngredientSort ingredientSort = IngredientSort.None;
    BoiledAbleIngredientSort boiledIngredientSort = BoiledAbleIngredientSort.None;

    public override void Initialize()
    {
        base.Initialize();
        SetAnimator();
        switch(gameObject.name)
        {

        }
        string originName = gameObject.name.Replace("(Clone)", "");
        switch (originName)
        {
            case "Onion":
                wholeObj = transform.GetChild(0).Find("Onion_Mesh").transform.Find("Onion_Whole").gameObject;
                sliceObj = transform.GetChild(0).Find("Onion_Mesh").transform.Find("Onion_Sliced").gameObject;
                boiledIngredientSort = BoiledAbleIngredientSort.Onion;
                ingredientSort = IngredientSort.Onion;
                sliceObj.SetActive(false);
                break;
            case "Mushroom":
                wholeObj = transform.GetChild(0).Find("MushRoom_Mesh").transform.Find("MushRoom_Whole").gameObject;
                sliceObj = transform.GetChild(0).Find("MushRoom_Mesh").transform.Find("MushRoom_Sliced").gameObject;
                boiledIngredientSort = BoiledAbleIngredientSort.Mushroom;
                ingredientSort = IngredientSort.Mushroom;
                sliceObj.SetActive(false);
                break;
            case "Beef":
                ingredientSort = IngredientSort.Beef;
                wholeObj = null;
                sliceObj = null;
                break;
        }
    }
  
    private void SetAnimator()
    {
        animator = transform.AddComponent<Animator>();
        string name = gameObject.name;
        string path = name.Replace("(Clone)", "");
        RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>(controllerPath + "/" + path);
        animator.runtimeAnimatorController = controller;
    }

    public BoiledAbleIngredientSort GetBoiledIngredientSort()
    {
        return boiledIngredientSort;
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
                Debug.Log("ï¿½ï¿½ï¿?ï¿½Ï·ï¿½");
            }
        }
    }

    public bool GetIsChopped()
    {
        return isChopped;
    }
}
