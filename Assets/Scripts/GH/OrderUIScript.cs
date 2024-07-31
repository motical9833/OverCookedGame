using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUIScript : MonoBehaviour
{
    Slider slider;
    public Image fill;

    Color greenColor = Color.green;
    Color redColor = Color.red;
    private float initialTimer = 80.0f;

    float currentTimer;

    void Start()
    {
        currentTimer = initialTimer;
        slider = this.gameObject.GetComponent<Transform>().GetChild(2).GetComponent<Slider>();
        fill = slider.GetComponent<Transform>().GetChild(1).GetChild(0).GetComponent<Image>();

        fill.color = greenColor;
    }

    void Update()
    {
        currentTimer -= Time.deltaTime;

        float ratio = Mathf.Clamp01(currentTimer / initialTimer);

        slider.value = ratio;

        float t = Mathf.PingPong(currentTimer / initialTimer, 1.0f);

        fill.color = Color.Lerp(redColor, greenColor, t);

        if (currentTimer <= 0)
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
        fill.color = greenColor;
    }
}