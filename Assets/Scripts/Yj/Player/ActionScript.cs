using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    Vector3 grabPos;
    GameObject frontCol;
    GameObject currGrabObj;


    //grab과 release는 space로 작동
    //Action은 leftCtrl로 작동
    private void CheckFrontObj()
    {
        if (frontCol.gameObject.tag == "IngredientBox")
        {
            frontCol.gameObject.GetComponent<IngredientObjectPoolScript>();
        }
    }

    public void CtrlAction()
    {

    }

    public void BarAction()
    {
        Debug.Log("Barpress");
        switch (frontCol.gameObject.tag)
        {
            case "IngredientBox":
                Debug.Log("ingredientbox col");
                
                frontCol.gameObject.GetComponent<IngredientObjectPoolScript>().GetIngredientPoolObject();
                
                
                break;
            case "Dish":

                break;
            case "Table":

                break;
            case "Ingredient":

                break;
        }


        //식재박스 위일때// 식재가 올라가 있는 블록일때 -> 우선순위//접시가 앞에 있을때// 냄비가 앞에 있을때
        //냄비를 들었을때 앞에 접시가 있다->우선순위
        //이미 타일에 물건이 올라갔을때->우선순위
    }

    public void Grab(GameObject grabObj) 
    {
        currGrabObj = grabObj;
        currGrabObj.transform.position = grabPos;
        //grab위치에 있는 obj를 parent로 설정
      /*  currGrabObj.transform.SetParent();*/
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
