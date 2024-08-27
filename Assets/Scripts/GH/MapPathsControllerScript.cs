using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPathsControllerScript : MonoBehaviour
{
    public void OpenPath(int procedure)
    {
        this.transform.GetChild(1).GetComponent<MapPathsScript>().UnLockPath(procedure);
    }

    public void InitializePathGrop()
    {
        GameObject gameManager = GameObject.FindWithTag("GameManager");
        MapPathsScript mapPathScript = this.transform.GetChild(1).GetComponent<MapPathsScript>();

        if (!gameManager)
        {
            Debug.Log("���� �Ŵ����� �������� ����");
            return;
        }

        List<Stage> stages = gameManager.GetComponent<StageSaveLoadScript>().GetStageList();

        //���� ���������� ���� �ø��� �� ���� �ʿ�
        for (int i = 0; i < 2; i++)
        {
            if (stages[i].GetStageInfo().isCleared)
            {
                mapPathScript.ActivePath(i);
            }
        }
    }
}