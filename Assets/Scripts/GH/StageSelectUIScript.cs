using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class StageSelectUIScript : MonoBehaviour
{
    private GameObject myStateUI;
    public GameObject[] startTexts = new GameObject[3];
    private GameObject player;
    private bool isSelect = false;

    private void Start()
    {
        myStateUI = gameObject.transform.GetChild(0).gameObject;

        for (int i = 0; i < startTexts.Length; i++)
        {
            startTexts[i] = myStateUI.transform.GetChild(i + 3).GetChild(2).gameObject;
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

    }

    public void SelectStage(Sprite img, StageInfo stageData)
    {
        if (isSelect)
            return;

        myStateUI.SetActive(true);
        myStateUI.transform.GetChild(1).GetComponent<Image>().sprite = img;

        for (int i = 0; i < startTexts.Length; i++)
        {
            startTexts[i].GetComponent<TextMeshProUGUI>().text = stageData.goals[i].ToString();
        }

        isSelect = true;
    }

    public void ExitStageSelect()
    {
        if (!isSelect)
            return;

        myStateUI.SetActive(false);
        isSelect = false;
        /*player.GetComponent<MoveScript>().enabled = true;*/
    }

    public void CancelStage()
    {
        myStateUI.SetActive(false);
    }

    public void StartStage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}