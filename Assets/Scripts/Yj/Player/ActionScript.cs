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

    //grab과 release는 space로 작동
    //Action은 leftCtrl로 작동

    public void InitialSet(BoxCollider _frontCol,GameObject _hand)
    {
        frontCol = _frontCol;
        hand = _hand;
    }

    public void CtrlAction()
    {

    }

    public bool BarAction()
    {
        Debug.Log("Barpress");

        if (currGrabObj == null)
        {
            Bounds fColBound = frontCol.bounds;
            Collider[] hitColliders = Physics.OverlapBox(fColBound.center, fColBound.extents, Quaternion.identity);

            foreach (Collider collider in hitColliders)
            {
                if (collider != frontCol)
                {
                    GameObject grabObj;
                    switch (collider.gameObject.tag)
                    {
                        case "Ingredient":
                            Debug.Log("ingredientbox");
                            grabObj = collider.gameObject;
                            Grab(grabObj);
                            return true;
                        case "IngredientBox":
                            Debug.Log("ingredientbox col");
                            grabObj = collider.gameObject.GetComponent<IngredientObjectPoolScript>().GetIngredientPoolObject();
                            Grab(grabObj);
                            return true;
                        case "Plate":

                            return true;
                    }
                }
            }
        }
        else
        {
            Release();
            return (true);
        }
        return (false);
        //식재박스 위일때// 식재가 올라가 있는 블록일때 -> 우선순위//접시가 앞에 있을때// 냄비가 앞에 있을때
        //냄비를 들었을때 앞에 접시가 있다->우선순위
        //이미 타일에 물건이 올라갔을때->우선순위
    }

    public void Grab(GameObject grabObj) 
    {
        currGrabObj = grabObj;
        currGrabObj.transform.position = hand.transform.position;
        grabObj.transform.SetParent(hand.transform);
        grabObj.GetComponent<IngredientScript>().Grabbed();
    }   

    public void Release()
    {
        currGrabObj.GetComponent<IngredientScript>().Release();
        currGrabObj.transform.parent = null;
        currGrabObj = null;
    }

    public void Chop()
    {

    }

    public void WashDish()
    {

    }

  
}
