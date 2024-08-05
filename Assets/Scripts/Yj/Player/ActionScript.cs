using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Enummrous;

public class ActionScript : MonoBehaviour
{
    Vector3 grabPos;
    BoxCollider frontCol;
    GameObject hand;
    GameObject currGrabObj;

    bool isGrab;

    //grab과 release는 space로 작동
    //Action은 leftCtrl로 작동

    public void InitialSet(BoxCollider _frontCol,GameObject _hand)
    {
        frontCol = _frontCol;
        hand = _hand;
        isGrab = false;
    }

    public void CtrlAction()
    {
        if (isGrab)
        {
            if (currGrabObj.tag == "Extinguisher")
            {
                //extinguishd애니메이션 재생 및 extinguisher에 작동 스크립트 적용
            }
            else
            {
                return;
            }
        }

        Bounds fColBound = frontCol.bounds;
        Collider[] hitColliders = Physics.OverlapBox(fColBound.center, fColBound.extents, Quaternion.identity);
       
        string[] tags = { "Table", "IngredientBox", "Pot", "Ingredient", "Plate" };

        foreach (string tag in tags)
        {
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag(tag))
                {
                    switch(collider.tag)
                    {
                     case "Table":
                            TableScript tableScr = collider.GetComponent<TableScript>();
                            if (tableScr.GetRaisedObject().tag == "CuttingBoard")
                            {
                                if (tableScr.GetTopRaisedObj().tag == "Ingredient")
                                {
                                    if(tableScr.GetTopRaisedObj().GetComponent<IngredientScript>().GetIsChopped())
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        //상태를 Chopping으로 돌려주기
                                        //음식물에 Chop 넣어주기
                                        //chop
                                    }
                                }
                            }
                            break;
                    }
                }
            }
                        
        }
    }

    public bool BarAction()
    {
        Debug.Log("Barpress");

        Bounds fColBound = frontCol.bounds;
        Collider[] hitColliders = Physics.OverlapBox(fColBound.center, fColBound.extents, Quaternion.identity);
       
        string[] tags = { "Table", "IngredientBox", "Pot", "Ingredient", "Plate" };

        if (isGrab)
        {
            #region"TryingRelease"
          
            foreach (string tag in tags)
            {
                foreach (Collider collider in hitColliders)
                {
                    if (collider.CompareTag(tag))
                    {
                        switch (tag)
                        {
                            case "Table":
                                TableScript tableScr = collider.GetComponent<TableScript>();
                                if (tableScr.IsRaised())
                                {
                                    switch(tableScr.GetRaisedObject().tag)
                                    {
                                        case "Pot":
                                            if (currGrabObj.tag == "Ingredient")
                                            {
                                                Debug.Log("재료를 솥에 넣음");
                                            }
                                            return false;
                                        case "Plate":
                                            Debug.Log("재료를 접시에 넣음");

                                            return false;
                                        case "CuttingBoard":
                                            if (currGrabObj.tag == "Ingredient")
                                            {
                                                tableScr.GetRaisedObject().GetComponent
                                                    <RaisedObjectScript>().RaisObject(currGrabObj);
                                                Release();
                                                return true;
                                            }
                                            Debug.Log("재료를 도마에 넣음");
                                            return false;
                                    }
                                    //만약 테이블에 올려진것이 Pot이나 Plate라면 true 리턴하고 계속 작성
                                    return false;
                                }
                                else
                                {
                                    collider.GetComponent<TableScript>().RaisObject(currGrabObj);
                                    Release();
                                    return true;
                                }
/*                            case "Plate":
                                if(collider.GetComponent<PlateScript>().g)*/

                        }
                    }
                }
            }
            #endregion
            return false;
        }
        #region"TryingGrab"
        else
        {
            foreach (string tag in tags)
            {
                foreach (Collider collider in hitColliders)
                {
                    if (collider.CompareTag(tag))
                    {
                        switch (tag)
                        {
                            case "Table":
                                TableScript tableScr = collider.GetComponent<TableScript>();

                                if (tableScr.IsRaised())
                                {
                                    switch (tableScr.GetRaisedObject().tag)
                                    {
                                        case "CuttingBoard":
                                            if (tableScr.GetRaisedObject().GetComponent<RaisedObjectScript>().GetRaisedObject().tag == "Ingredient")
                                            {
                                                currGrabObj = tableScr.GetRaisedObject().GetComponent<RaisedObjectScript>().GetRaisedObject();
                                                tableScr.GetRaisedObject().GetComponent<RaisedObjectScript>().Release();
                                                Grab(currGrabObj);
                                                return true;
                                            }
                                            else
                                            {
                                                return false;
                                            }
                                        case "Ingredient":
                                            currGrabObj = tableScr.GetRaisedObject();
                                            Grab(currGrabObj);
                                            tableScr.Release();
                                            return true;
                                    }
                                    return false;
                                }
                                else
                                {
                                    return false;
                                }
                            case "Pot":
                                currGrabObj = collider.GameObject();
                                Grab(currGrabObj);
                                return true;
                            case "IngredientBox":
                                IngredientObjectPoolScript ingObjPoolSrc;
                                ingObjPoolSrc = collider.GetComponent<IngredientObjectPoolScript>();
                                currGrabObj = ingObjPoolSrc.GetIngredientPoolObject();
                                Grab(currGrabObj);
                                return true;
                            case "Ingredient":
                                currGrabObj = collider.GameObject();
                                Grab(currGrabObj);
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion
    }

    public void Grab(GameObject grabObj) 
    {
        currGrabObj = grabObj;
        currGrabObj.transform.position = hand.transform.position;
        currGrabObj.transform.SetParent(hand.transform);
        currGrabObj.SendMessage("Grabbed");
        isGrab = true;
    }   



    public void Release()
    {
        currGrabObj.SendMessage("Release");
        currGrabObj.transform.parent = null;
        currGrabObj = null;
        isGrab = false;
    }

    public void Chop()
    {

    }

    public void WashDish()
    {

    }

  
}
