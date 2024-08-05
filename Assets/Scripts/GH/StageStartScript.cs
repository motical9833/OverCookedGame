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

    void Update()
    {
        
    }
}
