using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManagerScript : MonoBehaviour
{

    OrderUIControllerScript orderUIControllerScript;
    StageTimerScript stageTimerScript;
    StagePointScript stagePointScript;
    StageStartScript stageStartScript;

    GameManager gameManager;
    StageSaveLoadScript stageSaveLoadScript;

    void Start()
    {
        GameObject mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        stageSaveLoadScript = gameManager.GetComponent<StageSaveLoadScript>();

        stagePointScript = mainCanvas.transform.GetChild(1).GetComponent<StagePointScript>();
        stageTimerScript = mainCanvas.transform.GetChild(2).GetComponent<StageTimerScript>();
        stageStartScript = mainCanvas.transform.GetChild(3).GetComponent<StageStartScript>();

        orderUIControllerScript = this.GetComponent<OrderUIControllerScript>();

        StartCoroutine(GameStartCoroutine());
    }

    public void GameClear()
    {
        string name = SceneManager.GetActiveScene().name;
        int score = 10; /*stagePointScript.GetPoint();*/

        //StageInfo stageinfo = new StageInfo(name, score, false, true);

        StageInfo info = stageSaveLoadScript.GetPrevStageInfo();

        info.stageName = name;
        info.score = score;
        info.isCleared = true;
        info.isAble = true;

        stageSaveLoadScript.SavePrevStageInfo(info);

        stagePointScript.ResetPoint();
        stageTimerScript.ResetTimer();

        SceneManager.LoadSceneAsync("StageSelectScene");

        SceneManager.sceneLoaded += SceneLoad;
    }

    void StageInfoDeliver(string name,StageInfo info)
    {
        GameObject.Find(name).GetComponent<Stage>().SaveStageData(info);
    }


    public void SceneLoad(Scene scene, LoadSceneMode mode)
    {
        StageInfo info = stageSaveLoadScript.GetPrevStageInfo();

        string name = info.stageName;

        GameObject.Find(name).GetComponent<Stage>().SaveStageData(info);

        SceneManager.sceneLoaded -= SceneLoad;
    }

    IEnumerator GameStartCoroutine()
    {
        stageStartScript.ReadyGoUIOn();

        yield return new WaitForSeconds(4);

        orderUIControllerScript.OrderStart();
        stageTimerScript.StartTimer();
        stageTimerScript.EndTimeLimeted += GameClear;
    }
}