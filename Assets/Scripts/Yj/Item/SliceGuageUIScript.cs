using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliceGuageUIScript : MonoBehaviour
{
    private Transform targetCamTr;

    private Canvas canvas;
    public Slider sliderUi;


    private void Start()
    {
        targetCamTr = Camera.main.transform;
        sliderUi.minValue = 0.0f;
        sliderUi.maxValue = 100.0f;
        sliderUi.value = 0.0f;
    }

    void RookCamera()
    {
        //x�ุ �ٲ�����
      /*  Vector3 directionToCamera = targetCamTr.position - transform.position;
        directionToCamera.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        transform.rotation = targetRotation;*/
    }

    public void ShowSliceUI(float guage)
    {
        sliderUi.gameObject.SetActive(true);
        sliderUi.value = guage;
    }

    public void DisableSliceUI()
    {
        sliderUi.gameObject.SetActive(false);
    }

    // ī�޶� �°� ���� �����ֱ�..
    // slice�� ���� ���϶��� Ui�� �����ֱ�

}
