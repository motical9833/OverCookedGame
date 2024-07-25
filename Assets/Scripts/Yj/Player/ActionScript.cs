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

    public (PlayerState pState, bool isAct) BarAction()
    {
        Debug.Log("Barpress");

        Bounds fColBound = frontCol.bounds;
        Collider[] hitColliders = Physics.OverlapBox(fColBound.center, fColBound.extents, Quaternion.identity);
        
        foreach (Collider collider in hitColliders)
        {
            if (collider != frontCol)
            {
                switch (collider.gameObject.tag)
                {
                    case "IngredientBox":
                        Debug.Log("ingredientbox col");
                        GameObject grabObj = collider.gameObject.GetComponent<IngredientObjectPoolScript>().GetIngredientPoolObject();
                        Grab(grabObj);
                        return (PlayerState.Hold, true);
                    case "Dish":

                        return (PlayerState.Hold, true);
                }
            }
        }
        return (PlayerState.End, false);


        //식재박스 위일때// 식재가 올라가 있는 블록일때 -> 우선순위//접시가 앞에 있을때// 냄비가 앞에 있을때
        //냄비를 들었을때 앞에 접시가 있다->우선순위
        //이미 타일에 물건이 올라갔을때->우선순위
    }

    public void Grab(GameObject grabObj) 
    {
        currGrabObj = grabObj;
        grabObj.transform.SetParent(hand.transform);
    }

    public void Release()
    {

    }

    public void Chop()
    {

    }

    public void WashDish()
    {

    }

  
}
