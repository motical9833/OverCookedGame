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
        slider = this.gameObject.GetComponent<Transform>().GetChild(3).GetComponent<Slider>();
    }

    void Update()
    {
        currentTimer -= Time.deltaTime;

        float ratio = currentTimer / initialTimer;

        slider.value = ratio;
    }
}
