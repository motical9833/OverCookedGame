using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enummrous;
using UnityEngine.UI;

public class PotScript : GrabAbleObjScript
{

    private int addCount = 0;

    public float currTimeLimit = 0;
    public float initTimeLimit = 0;
    private float boilingTime = 0;

    float alertTime;

    bool isboiledDone = false; // ��� ��Ⱑ ������
    bool isCookedDone = false; // ���� ��� ���� �־� ��°��� ������

    Image alertImage;
    Image dangerImage;

    private PotUIControllerScript potUICtrlScr;

    private string firstAddedName = "";

    void Start()
    {
        base.Initialize();
        potUICtrlScr = GetComponent<PotUIControllerScript>();
    }

    public bool PutIngredient(string ingredientName)
    {
        foreach (IngredientInfo.IngredientElements ingredient in IngredientInfo.Ingredients)
        {
            if (ingredientName == ingredient.name)
            {
                if (!ingredient.GetIsBoiled())
                {
                    return false;
                }
                if (firstAddedName == "")
                {
                    firstAddedName = ingredientName;
                    addCount++;
                    return true;
                }
                if (firstAddedName != ingredientName)
                {
                    return false;
                }
                else
                {
                    addCount++;
                    return true;
                }
            }
        }
        return false;
    }

    public void Boiled()
    {
        foreach (IngredientInfo.IngredientElements ingredient in IngredientInfo.Ingredients)
        {
            if(firstAddedName != "")
            {
                boilingTime += Time.deltaTime;
                if (boilingTime >= currTimeLimit)
                {
                    isboiledDone = true;
                }
                else
                {
                    isboiledDone = false;
                }
            }

        }
    }
}

