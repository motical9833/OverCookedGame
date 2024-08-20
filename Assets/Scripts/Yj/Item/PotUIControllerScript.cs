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

    private void Start()
    {
        foreach (var image in addedImages)
        {
            image.gameObject.SetActive(false);
        }
    }

    public void ShowAddedImage(int addedAmount ,string addedName)
    {
        // 0~2까지는  1 2 이미지 온

        // 3 은  1 2 이미지 끄고 3 4 5 번 켜주기

        //stuct로 리팩토링한 Ingredient에서 이미지 이름 가져와서 resources//2d에서 이미지 불러오기
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

    public void ResetAll()
    {

    }

    public void ShowBoilingTimer()
    {

    }
}
