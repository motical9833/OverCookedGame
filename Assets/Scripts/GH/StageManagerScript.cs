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

    StageSaveLoadScript stageSaveLoadScript;

    void Start()
    {
        GameObject mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        stageSaveLoadScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<StageSaveLoadScript>();

        stagePointScript = mainCanvas.transform.GetChild(1).GetComponent<StagePointScript>();
        stageTimerScript = mainCanvas.transform.GetChild(2).GetComponent<StageTimerScript>();
        stageStartScript = mainCanvas.transform.GetChild(3).GetComponent<StageStartScript>();

        orderUIControllerScript = this.GetComponent<OrderUIControllerScript>();

        StartCoroutine(GameStartCoroutine());
    }

    public void GameClear()
    {
        string name = SceneManager.GetActiveScene().name;
        int score = 80; /*stagePointScript.GetPoint();*/

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
}