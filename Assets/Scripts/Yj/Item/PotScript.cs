using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enummrous;
using UnityEngine.UI;

public class PotScript : GrabAbleObjScript
{
    BoiledAbleIngredientSort firstAddedIngredient = BoiledAbleIngredientSort.None;
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

    void Start()
    {
        base.Initialize();
        potUICtrlScr = GetComponent<PotUIControllerScript>();
    }

    public bool PutIngredient(BoiledAbleIngredientSort addIngredient)
    {
        if(addIngredient == BoiledAbleIngredientSort.None)
        {
            return false;
        }
        if (firstAddedIngredient == BoiledAbleIngredientSort.None)
        {
            firstAddedIngredient = addIngredient;
            addCount++;
            return true;
        }
        else
        {
            if(addIngredient != firstAddedIngredient)
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

    public void Boiled()
    {
        if(firstAddedIngredient != BoiledAbleIngredientSort.None)
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

