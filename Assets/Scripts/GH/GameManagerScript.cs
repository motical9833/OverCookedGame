using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Stage> stages;

    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoad;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StageSelectScene");
        }
    }


    public void SceneLoad(Scene scene, LoadSceneMode mode)
    {
        GameObject objs = GameObject.Find("StageObjects");

        for (int i = 0; i < objs.transform.childCount; i++)
        {
            stages.Add(objs.transform.GetChild(i).GetComponent<Stage>());
        }

        foreach (Stage stage in stages)
        {
            stage.LoadStageData();
            stage.PrintStageInfo();
        }

        SceneManager.sceneLoaded -= SceneLoad;
    }

    public void SaveAllStages()
    {
        foreach (Stage stage in stages)
        {
            stage.SaveStageData();
        }
        Debug.Log("ALL stage data saved.");
    }

    public void LoadAllStages()
    {
        foreach (Stage stage in stages)
        {
            stage.LoadStageData();
        }
        Debug.Log("All stage data loaded.");
    }
}
