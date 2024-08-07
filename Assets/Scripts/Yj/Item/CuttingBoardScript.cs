using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingBoardScript : RaisedObjectScript
{
    public GameObject knife;
    bool isCutting = false;
    private void Update()
    {
        if (isCutting)
        {
            GetRaisedObject().GetComponent<IngredientScript>().Chop();
        }
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
