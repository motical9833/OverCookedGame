using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;

public class StageTimerScript : MonoBehaviour
{
    public float stageTimeLimit = 240.0f;
    TextMeshProUGUI textMeshGUI = null;
    bool isStart = false;

    void Start()
    {
        textMeshGUI = this.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textMeshGUI.text = (stageTimeLimit / 60.0f).ToString() + ":" + (stageTimeLimit % 60.0f).ToString();
    }

    void Update()
    {
        if (!isStart)
            return;

        stageTimeLimit -= Time.deltaTime;

        textMeshGUI.text = ((int)(stageTimeLimit / 60) + ":" + (int)(stageTimeLimit % 60)).ToString();
    }

    public void StartTimer()
    {
        isStart = true;
    }
}