using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enummrous;
using System.Net.Http.Headers;
using Mono.Cecil;
using System.Threading;
public class PotUIControllerScript : MonoBehaviour
{

    public Image[] addedImages = new Image[5];
    public Slider boilingGuage;

    public Image finishImage;

    private bool isImageOn = false;

    private float alertTimer;
    public Image burnWarningUIImage;

    private void Start()
    {
        boilingGuage.minValue = 0.0f;
        boilingGuage.maxValue = 100.0f;

        foreach (var image in addedImages)
        {
            image.gameObject.SetActive(false);
        }

        burnWarningUIImage.gameObject.SetActive(false);
        boilingGuage.gameObject.SetActive(false);
    }

    public void ShowAddedImage(int addedAmount ,string addedName)
    {
        // 0~2������  1 2 �̹��� ��

        // 3 ��  1 2 �̹��� ���� 3 4 5 �� ���ֱ�

        //stuct�� �����丵�� Ingredient���� �̹��� �̸� �����ͼ� resources//2d���� �̹��� �ҷ�����
        for (int i = 0; i < IngredientInfo.Ingredients.Count; i++)
        {
            if (addedName == IngredientInfo.Ingredients[i].name)
            {
                foreach(Image addedImage in addedImages)
                {
                    addedImage.sprite = Resources.Load<Sprite>(IngredientInfo.Ingredients[i].reousrce2DPath);
                }
            }
        }
        switch (addedAmount)
        {
            case 0:

                break;
            case 1:
                addedImages[0].gameObject.SetActive(true);
                break;
            case 2:
                addedImages[1].gameObject.SetActive(true);
                break;
            case 3:
                addedImages[2].gameObject.SetActive(true);
                addedImages[3].gameObject.SetActive(true);
                addedImages[4].gameObject.SetActive(true);
                
                addedImages[0].gameObject.SetActive(false);
                addedImages[1].gameObject.SetActive(false);
                break;
        }
    }

    public void HideAddedImage()
    {
        foreach (Image addedImage in addedImages)
        {
            addedImage.gameObject.SetActive(false);
        }
    }

    public void SetMax(float value) { boilingGuage.maxValue = value; }

    public void ShowFinishUI()
    {
        Color fColor = finishImage.color;
        if (!isImageOn)
        {
            fColor.a += 0.5f;
            if (fColor.a >= 1.0f)
            {
                fColor.a = 1.0f;
                isImageOn = true;
            }
        }
        if (isImageOn)
        {
            fColor.a -= 0.5f;
        }
    }

    public void ShowBoilingGuage(float _value)
    {
        boilingGuage.gameObject.SetActive(true);
        boilingGuage.value = _value;
    }

    public void HideBoilingGuage()
    {
        boilingGuage.gameObject.SetActive(false);
    }

    public void ResetAll()
    {

    }

    public void Blink(float time)
    {
        Color color = burnWarningUIImage.color;
        var interval = time;
        alertTimer += Time.deltaTime;
        if(alertTimer>=interval)
        {
            if (burnWarningUIImage.gameObject.activeInHierarchy)
            {
                color.a += 0.5f;
                burnWarningUIImage.gameObject.SetActive(false);
            }
            else
                burnWarningUIImage.gameObject.SetActive(true);

            alertTimer = 0;
        }
    }
}
