using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Stage : MonoBehaviour
{

    private StageInfo stageInfo;

    private string filePath;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, gameObject.name + "_stagedata.json");
    }


    public void SaveStageData()
    {
        string json = JsonUtility.ToJson(stageInfo, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Stage data saved to " + filePath);
    }

    public void LoadStageData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            stageInfo = JsonUtility.FromJson<StageInfo>(json);
            Debug.Log("Stage data loaded from " + filePath);
        }
        else
        {
            Debug.LogWarning("Stage data file not found for " + gameObject.name);

            if(gameObject.name == "Level 1-1")
            {
                stageInfo = new StageInfo(gameObject.name, 0, false, true);
            }
            else
            {
                stageInfo = new StageInfo(gameObject.name, 0, false, false); // 기본 값 설정
            }
            SaveStageData(); // 기본 값을 저장
        }
        StartStageSetting();
    }

    // 스테이지 정보 출력
    public void PrintStageInfo()
    {
        Debug.Log("Stage: " + stageInfo.stageName + ", score: " + stageInfo.score + ", Cleared: " + stageInfo.isCleared);
    }

    public void StartStageSetting()
    {
        if(stageInfo.isAble == false)
        {
            this.gameObject.gameObject.SetActive(false);
        }
    }
}