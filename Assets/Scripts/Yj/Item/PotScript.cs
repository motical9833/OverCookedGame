using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enummrous;
using UnityEngine.UI;


public class PotScript : GrabAbleObjScript
{

    private int addCount = 0;

    public float currTimeLimit = 5.0f;
    public float initTimeLimit = 0;

    private float boilingTime = 0.0f;
    public float boilingDoneTime = 5.0f;

    float alertTime;

    bool isboiledDone = false; // ��� ��Ⱑ ������
    bool isCookedDone = false; // ���� ��� ���� �־� ��°��� ������

    private PotUIControllerScript potUICtrlScr;

    private string firstAddedName = "";

    void Start()
    {
        base.Initialize();
        potUICtrlScr = GetComponent<PotUIControllerScript>();
    }

    public bool PutIngredient(string ingredientName)
    {
        Debug.Log("��Ḧ �ܿ� ����");
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
                    addCount += 1;
                    currTimeLimit = addCount * boilingDoneTime;
                    potUICtrlScr.SetMax(currTimeLimit);
                    potUICtrlScr.ShowAddedImage(1, firstAddedName);
                    Debug.Log("ù ��° ���� " + ingredientName + "�� ����");
                    return true;
                }
                if (firstAddedName != ingredientName)
                {
                    return false;
                }
                else
                {
                    addCount += 1;
                    currTimeLimit = addCount * boilingDoneTime;
                    potUICtrlScr.SetMax(currTimeLimit);
                    potUICtrlScr.ShowAddedImage(addCount, firstAddedName);
                    return true;
                }
            }
        }
        return false;
    }


    public void Boiled()
    {
        if (firstAddedName != "")
        {
            potUICtrlScr.ShowBoilingGuage(boilingTime);
            if (boilingTime >= currTimeLimit)
            {
                isboiledDone = true;
            }
            else
            {
                boilingTime += Time.deltaTime;
                isboiledDone = false;
                Debug.Log("���̴� ��");
            }
        }
    }
}

