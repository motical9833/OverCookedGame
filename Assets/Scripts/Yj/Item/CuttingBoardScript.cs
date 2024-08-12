using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardScript : RaisedObjectScript
{
    public GameObject knife;
    bool isCutting = false;

    int cutters = 0;

    private void Update()
    {
        if (cutters <= 0)
        {
            SetCutting(false);
            return;
        }
        if (GetRaisedObject() != null && GetRaisedObject().GetComponent<IngredientScript>().GetIsChopped())
        {
            SetCutting(false);
            return;
        }
        if (cutters > 0)
        {
            SetCutting(true);
            GetRaisedObject().GetComponent<IngredientScript>().Chopping();
        }
    }

    public void AddCutter()
    {
        cutters += 1;
        Debug.Log(cutters);
    }


    public void RemoveCutter()
    {
        cutters -= 1;
        Debug.Log(cutters);
    }


    public void SetCutting(bool cutOnOff)
    {
        if (cutOnOff)
        {
            isCutting = true;
            knife.SetActive(false);
        }    
        else
        {
            isCutting = false;
            knife.SetActive(true);
        }
    }

    public bool GetChoppingIsDone()
    {
        return false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isCutting)
            {
                Debug.Log("플레이어가 도마 위를 벗어남");
                SetCutting(false);
            }
        }
    }
}
