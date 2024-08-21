using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enummrous;
using System.Net.Http.Headers;
using Mono.Cecil;
public class PotUIControllerScript : MonoBehaviour
{

    private Image alertImage;
    private Image dangerImage;
    private Image addedIcon;
    private float blinkTimer;

    public Image[] addedImages = new Image[5];

    public Slider boilingGuage;

    private void Start()
    {
        boilingGuage.minValue = 0.0f;
        boilingGuage.maxValue = 100.0f;

        foreach (var image in addedImages)
        {
            image.gameObject.SetActive(false);
        }
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
    public void ShowBoilingGuage(float _value)
    {
        boilingGuage.gameObject.SetActive(true);
        boilingGuage.value = _value;
    }

    public void HideBoilingGuage()
    {
        boilingGuage.value = 0.0f;
        boilingGuage.gameObject.SetActive(false);
    }

    public void ResetAll()
    {

    }

   
}
