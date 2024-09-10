using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enummrous;
using UnityEngine.UI;


public class PotScript : GrabAbleObjScript
{

    private int addCount = 0;

    private float currTimeLimit = 5.0f;

    public float[] alertTimes = new float[4];
    private float alertTimer = 0.0f;

    private float boilingDoneTime = 5.0f;
    private float boilingTimer = 0.0f;

    private float burningTimer = 0.0f;



    bool isboiledDone = false; // ��� ��Ⱑ ������
    bool isCookedDone = false; // ���� ��� ���� �־� ��°��� ������

    bool isFire = false; // ��Ÿ����

    float extinguishGuage;
    float extinguishPower; // ex 3�ʸ��� ��ȭ

    private PotUIControllerScript potUICtrlScr;

    private string firstAddedName = "";

    public GameObject fireEffect;

    void Start()
    {
        base.Initialize();
        potUICtrlScr = GetComponent<PotUIControllerScript>();
        potUICtrlScr.HideBoilingGuage();
        fireEffect.SetActive(false);
    }


    public bool PutIngredient(string ingredientName)
    {
        Debug.Log("��Ḧ �ܿ� ����");

        if (addCount >= 3)
        {
            Debug.Log("3�� �̻��� ��Ḧ �������� �õ���");
            return false;
        }

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
        if(isFire)
        {
            return;
        }

        if (firstAddedName != "")
        {
            if (boilingTimer >= currTimeLimit)
            {
                isboiledDone = true;
                if (addCount >= 3)
                {
                    addCount = 3;
                    isCookedDone = true;    
                }
                potUICtrlScr.HideBoilingGuage();
                ShowAlertUI();
                burningTimer += Time.deltaTime;
                if (burningTimer >= alertTimes[3])
                {
                    Burn();
                }
            }
            else
            {
                boilingTimer += Time.deltaTime;
                potUICtrlScr.ShowBoilingGuage(boilingTimer);
                isboiledDone = false;
                Debug.Log("���̴� ��");
            }
        }
    }

    private void Burn()
    {
        fireEffect.SetActive(true);
    }

    public void Extinguish()
    {
        extinguishGuage += (100.0f / extinguishPower);
        if (extinguishGuage >= 100.0f)
        {
            extinguishGuage = 0.0f;
            burningTimer = 0.0f;
            isFire = false;
        }
    }

    private void ShowDoneUI()
    {

    }

    private void ShowAlertUI()
    {
        alertTimer += Time.deltaTime;

        if (alertTimes[0] < alertTimer && alertTimes[1] >= alertTimer)
        {
            potUICtrlScr.Blink(1);
        }
        if(alertTimes[1] < alertTimer && alertTimes[2] >= alertTimer)
        {
            potUICtrlScr.Blink(0.5f);
        }
        if (alertTimes[2] < alertTimer && alertTimes[3] >= alertTimer)
        {
            potUICtrlScr.Blink(0.25f);
        }
        if (alertTimes[3] >= alertTimer)
        {
            /*Burn();*/
        }
    }


    public bool GetIsCookedDone()
    {
        return isCookedDone;
    }

    public bool PlatingSoup(PlateScript targetScr)
    {
        if (!isCookedDone)
            return false;
        targetScr.PlateSoup(firstAddedName);
        firstAddedName = "";
        addCount = 0;
        isCookedDone = false;
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="ExtinguisherPowder")
        {
            Extinguish();
        }
    }
}
