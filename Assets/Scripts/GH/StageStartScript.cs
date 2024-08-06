using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStartScript : MonoBehaviour
{
    public GameObject[] readyGoUIObjects = new GameObject[2];

    void Start()
    {
        for (int i = 0; i < readyGoUIObjects.Length; i++)
        {
            readyGoUIObjects[i] = this.transform.GetChild(i).gameObject;

            if (readyGoUIObjects[i] == null)
            {
                Debug.Log("ReadyUI or GoUI »ç¶óÁü");
            }
        }
    }


    IEnumerator StartUICoroutine()
    {
        readyGoUIObjects[0].SetActive(true);

        yield return new WaitForSeconds(3);

        readyGoUIObjects[0].SetActive(false);
        readyGoUIObjects[1].SetActive(true);

        yield return new WaitForSeconds(1);

        readyGoUIObjects[0].SetActive(false);
        readyGoUIObjects[1].SetActive(false);
    }

    public void ReadyGoUIOn()
    {
        StartCoroutine(StartUICoroutine());
    }
}
