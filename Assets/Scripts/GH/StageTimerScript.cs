using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;

public class StageTimerScript : MonoBehaviour
{
    float stageTimeLimit = 300.0f;
    float timeupTime = 5.0f;
    TextMeshProUGUI textMeshGUI = null;
    bool isStart = false;
    bool isTimeUP = false;

    public event Action EndTimeLimeted;

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

        if (stageTimeLimit < 0 && !isTimeUP)
        {
            isStart = false;
            isTimeUP = true;
            StartCoroutine(TimeUPUICoroutine());
        }
    }

    IEnumerator TimeUPUICoroutine()
    {
        GameObject audioManager = GameObject.FindWithTag("AudioManager");
        if (!audioManager)
        {
            Debug.Log("오디오 매니저가 존재하지 않음!");
        }
        GameObject timeUpPanal = this.transform.GetChild(2).gameObject;
        timeUpPanal.SetActive(true);
        timeUpPanal.GetComponent<TimeUPUIScript>().TimeUP();
       

        audioManager.GetComponent<BGMScript>().StartBGM("TimesUpSting",false);

        yield return new WaitForSeconds(timeupTime);
        EndTimeLimeted();
    }

    public void StartTimer()
    {
        isStart = true;
    }
}