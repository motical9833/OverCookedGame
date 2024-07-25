using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    Vector3 grabPos;
    GameObject frontCol;
    GameObject currGrabObj;


    //grab�� release�� space�� �۵�
    //Action�� leftCtrl�� �۵�
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


        //����ڽ� ���϶�// ���簡 �ö� �ִ� ����϶� -> �켱����//���ð� �տ� ������// ���� �տ� ������
        //���� ������� �տ� ���ð� �ִ�->�켱����
        //�̹� Ÿ�Ͽ� ������ �ö�����->�켱����
    }

    public void Grab(GameObject grabObj) 
    {
        currGrabObj = grabObj;
        currGrabObj.transform.position = grabPos;
        //grab��ġ�� �ִ� obj�� parent�� ����
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
