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

    //grab�� release�� space�� �۵�
    //Action�� leftCtrl�� �۵�

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
                    switch (collider.gameObject.tag)
                    {
                        case "IngredientBox":
                            Debug.Log("ingredientbox col");
                            GameObject grabObj = collider.gameObject.GetComponent<IngredientObjectPoolScript>().GetIngredientPoolObject();
                            Grab(grabObj);
                            return (true);
                        case "Dish":

                            return (true);
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
        //����ڽ� ���϶�// ���簡 �ö� �ִ� ����϶� -> �켱����//���ð� �տ� ������// ���� �տ� ������
        //���� ������� �տ� ���ð� �ִ�->�켱����
        //�̹� Ÿ�Ͽ� ������ �ö�����->�켱����
    }

    public void Grab(GameObject grabObj) 
    {
        currGrabObj = grabObj;
        grabObj.transform.SetParent(hand.transform);
    }

    public void Release()
    {
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
