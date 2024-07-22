using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStageScript : MonoBehaviour
{
    public StageSelectUIScript stageSelectUIScript;
    private GameObject stageObject;
    bool isSelectStage = false;
    private float delayTime = 0.0f;

    void Start()
    {
        stageSelectUIScript = GameObject.Find("MainCanvas").GetComponent<StageSelectUIScript>();
    }

    void Update()
    {
        if(delayTime >= 1.0f)
        {
            StartStage();
            SelectStage();
            ExitSelectStage();
        }
        else
        {
            delayTime += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        stageObject = other.gameObject;
    }

    private void StageSelect(Sprite img, StageInfo stageData)
    {
        stageSelectUIScript.SelectStage(img, stageData);
        this.gameObject.GetComponent<MoveScript>().enabled = false;
    }

    private void SelectStage()
    {
        if (!isSelectStage && Input.GetKeyDown(KeyCode.Space))
        {
            StageSelect(stageObject.GetComponent<Stage>().GetStageImg(), stageObject.GetComponent<Stage>().GetStageInfo());
            isSelectStage = true;
        }
    }

    private void ExitSelectStage()
    {
        if (isSelectStage && Input.GetKeyDown(KeyCode.Escape))
        {
            stageSelectUIScript.ExitStageSelect();
            isSelectStage = false;
        }
    }

    private void StartStage()
    {
        if(isSelectStage && Input.GetKeyDown(KeyCode.Space))
        {
            stageSelectUIScript.ExitStageSelect();
            isSelectStage = false;
            stageSelectUIScript.StartStage(stageObject.name);
        }
    }
}
