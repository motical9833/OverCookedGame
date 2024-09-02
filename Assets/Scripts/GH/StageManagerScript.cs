using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManagerScript : MonoBehaviour
{

    int gameScore = 0;
    int orderFailedCount = 0;
    int tips = 0;

    OrderUIControllerScript orderUIControllerScript;
    StageTimerScript stageTimerScript;
    StagePointScript stagePointScript;
    StageStartScript stageStartScript;

    StageSaveLoadScript stageSaveLoadScript;

    void Start()
    {
        stageSaveLoadScript = GameObject.FindGameObjectWithTag("GameManager")?.GetComponent<StageSaveLoadScript>();
        GameObject mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");

        if(!stageSaveLoadScript || mainCanvas)
        {
            Debug.Log("스크립트를 찾을 수 없음");
            return;
        }

        stagePointScript = mainCanvas.transform.GetChild(1).GetComponent<StagePointScript>();
        stageTimerScript = mainCanvas.transform.GetChild(2).GetComponent<StageTimerScript>();
        stageStartScript = mainCanvas.transform.GetChild(3).GetComponent<StageStartScript>();

        orderUIControllerScript = this.GetComponent<OrderUIControllerScript>();

        StartCoroutine(GameStartCoroutine());
    }

    public void GameClear()
    {
        string name = SceneManager.GetActiveScene().name;
        int score = gameScore;

        StageInfo info = stageSaveLoadScript.GetPrevStageInfo();

        info.stageName = name;
        info.score = score;
        info.isCleared = true;
        info.isAble = true;

        stageSaveLoadScript.SavePrevStageInfo(info);

        stagePointScript.ResetPoint();

        SceneManager.LoadSceneAsync("StageSelectScene");

        SceneManager.sceneLoaded += SaveClearDataAndLoadScene;
        stageSaveLoadScript.StageToSceneLoad();
    }

    public void GameFailed()
    {
        stagePointScript.ResetPoint();

        SceneManager.LoadSceneAsync("StageSelectScene");

        SceneManager.sceneLoaded += SaveClearDataAndLoadScene;
        stageSaveLoadScript.StageToSceneLoad();
    }

    void StageInfoDeliver(string name,StageInfo info)
    {
        GameObject.Find(name).GetComponent<Stage>().SaveStageData(info);
    }


    public void SaveClearDataAndLoadScene(Scene scene, LoadSceneMode mode)
    {
        StageInfo info = stageSaveLoadScript.GetPrevStageInfo();

        string name = info.stageName;

        GameObject stage = GameObject.Find(name);

        GameObject mapObject = GameObject.FindWithTag("MapObject");

        GameObject audioManager = GameObject.FindWithTag("AudioManager");

        stage.GetComponent<Stage>().SaveStageData(info);

        int count = info.GetStarCount();

        stage.GetComponent<StarLevelUIControllerScript>().SetStarImageBasedOnCount(count);

        GameObject.FindWithTag("StageObject").GetComponent<StageObjectsControllerScript>().OpenStage();

        int procedure = stage.GetComponent<Stage>().GetStageInfo().procedure;

        mapObject.GetComponent<MapGridController>().TileFlipping(procedure + 1);
        mapObject.GetComponent<MapPathsControllerScript>().OpenPath(procedure);

        audioManager.GetComponent<BGMScript>().StartBGM("StartScreenMusic",true);

        SceneManager.sceneLoaded -= SaveClearDataAndLoadScene;
    }

    IEnumerator GameStartCoroutine()
    {
        stageStartScript.ReadyGoUIOn();

        yield return new WaitForSeconds(4);

        orderUIControllerScript.OrderStart();
        stageTimerScript.StartTimer();
        stageTimerScript.EndTimeLimeted += GameClear;
    }

    public void SetScore(int score)
    {
        gameScore = score;
    }

    public void SetOrderFailedCount(int count)
    {
        orderFailedCount = count;
    }

    public void SetTips(int tip)
    {
        tips = tip;
    }

    public int GetScore()
    {
        return gameScore;
    }
    public int GetOrderFailedCount()
    {
        return orderFailedCount;
    }
    public int GetTips()
    {
        return tips;
    }
}