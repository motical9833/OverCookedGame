using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PotUIControllerScript : MonoBehaviour
{

    private Image alertImage;
    private Image dangerImage;
    private Image addedIcon;
    private float blinkTimer;

    private Image[] addedImage = new Image[5];

    public void Blink()
    {

    }

    public void ShowAddedImage(int addedAmount)
    {
        // 0~2까지는  1 2 이미지 온

        // 3 은  1 2 이미지 끄고 3 4 5 번 켜주기

        //stuct로 리팩토링한 Ingredient에서 이미지 이름 가져와서 resources//2d에서 이미지 불러오기
    }

    public void ResetAll()
    {

    }

    public void ShowBoilingTimer()
    {

    }
}
