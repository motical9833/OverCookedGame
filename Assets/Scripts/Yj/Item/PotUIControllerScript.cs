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
        // 0~2������  1 2 �̹��� ��

        // 3 ��  1 2 �̹��� ���� 3 4 5 �� ���ֱ�

        //stuct�� �����丵�� Ingredient���� �̹��� �̸� �����ͼ� resources//2d���� �̹��� �ҷ�����
    }

    public void ResetAll()
    {

    }

    public void ShowBoilingTimer()
    {

    }
}
