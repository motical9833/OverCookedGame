using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using System.Xml;

public class StageSaveLoadScript : MonoBehaviour
{
    //public List<Stage> stages;

    public Dictionary<string, Stage> stageDictionary;

    StageInfo prevStageInfo;

    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoad;
        prevStageInfo = new StageInfo();
        stageDictionary = new Dictionary<string, Stage>();
    }

    public void StageToSceneLoad()
    {
        SceneManager.sceneLoaded += SceneLoad;
    }

    public void SceneLoad(Scene scene, LoadSceneMode mode)
    {
       // stages.Clear();

        stageDictionary.Clear();

        GameObject objs = GameObject.Find("StageObjects");

        for (int i = 0; i < objs.transform.childCount; i++)
        {
            //stages.Add(objs.transform.GetChild(i).GetComponent<Stage>());

            stageDictionary.Add(objs.transform.GetChild(i).name, objs.transform.GetChild(i).GetComponent<Stage>());
        }

/*        foreach (Stage stage in stages)
        {
            stage.LoadStageData();
        }*/

        foreach (Stage value in stageDictionary.Values)
        {
            value.LoadStageData();
        }

        SceneManager.sceneLoaded -= SceneLoad;
    }

    public void SaveAllStages()
    {
/*        foreach (Stage stage in stages)
        {
            stage.SaveStageData();
        }*/


        foreach (Stage value in stageDictionary.Values)
        {
            value.LoadStageData();
        }
        Debug.Log("ALL stage data saved.");
    }

    public void LoadAllStages()
    {
/*        foreach (Stage stage in stages)
        {
            stage.LoadStageData();
        }*/


        foreach (Stage value in stageDictionary.Values)
        {
            value.LoadStageData();
        }
        Debug.Log("All stage data loaded.");
    }

    public void SavePrevStageInfo(StageInfo info)
    {
        prevStageInfo = info;

        Debug.Log(prevStageInfo.stageName + ":" + prevStageInfo.score);
    }

    public StageInfo GetPrevStageInfo()
    {
        return prevStageInfo;
    }
}
