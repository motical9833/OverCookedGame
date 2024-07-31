using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUIScript : MonoBehaviour
{
    Slider slider;
    public float currentTimer = 80.0f;

    private float initialTimer;

    void Start()
    {
        initialTimer = currentTimer;
        slider = this.gameObject.GetComponent<Transform>().GetChild(2).GetComponent<Slider>();
    }

    void Update()
    {
        currentTimer -= Time.deltaTime;

        float ratio = currentTimer / initialTimer;

        slider.value = ratio;

        if(currentTimer < 0)
        {
            ResetTimer();
        }
    }

    public float GetCurrentTime()
    {
        return currentTimer;
    }

    public void ResetTimer()
    {
        currentTimer = 80.0f;
        slider.value = 1;
    }
}