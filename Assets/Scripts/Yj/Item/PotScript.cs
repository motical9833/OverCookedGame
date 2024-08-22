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

    public float safeTime = 0.0f;
    public float safeTimer = 0.0f;

    public float[] alertTimes = new float[3];
    public float alertTimer = 0.0f;

    private float boilingTime = 0.0f;
    public float boilingDoneTime = 5.0f;
    public Image alertImage;


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
                ShowAlertUI();
            }
            else
            {
                boilingTime += Time.deltaTime;
                isboiledDone = false;
                Debug.Log("���̴� ��");
            }
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
            Blink(2);
        }
        if(alertTimes[1] < alertTimer && alertTimes[2] >= alertTimer)
        {
            Blink(1);
        }
        if (alertTimes[2] < alertTimer && alertTimes[3] >= alertTimer)
        {
            Blink(0.5f);
        }
        if (alertTimes[3] >= alertTimer)
        {
            /*Burn();*/
        }
    }

    public void Blink(float time)
    {
        StartCoroutine(BlinkCoroutine(time));
    }

    private IEnumerator BlinkCoroutine(float time)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            alertImage.gameObject.SetActive(true); // �̹��� Ȱ��ȭ
            yield return new WaitForSeconds(0.5f); // Ȱ��ȭ ���� ���� �ð�
            alertImage.gameObject.SetActive(false); // �̹��� ��Ȱ��ȭ
            yield return new WaitForSeconds(0.5f); // ��Ȱ��ȭ ���� ���� �ð�

            elapsedTime += 1f; // 1��(Ȱ��ȭ 0.5�� + ��Ȱ��ȭ 0.5��) ��ŭ ��� �ð� ����
        }

        alertImage.gameObject.SetActive(true); // ������ ���� �� �̹��� Ȱ��ȭ ���� ����
    }
}
