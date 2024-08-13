using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Enummrous;

public class ActionScript : MonoBehaviour
{
    Vector3 grabPos;

    BoxCollider frontCol = null;

    GameObject hand = null; 
    
    GameObject currGrabObj = null; // ���� ���� ������ �ִ� ������Ʈ
    GameObject currCuttingBoard = null; // ���� ���� ����ϰ� �ִ� ����

    bool isGrab = false;
    bool isChop = false;

    //grab�� release�� space�� �۵�
    //Action�� leftCtrl�� �۵�

    PlayerAnimationScript pAnimScript;

    public void InitialSet(BoxCollider _frontCol,GameObject _hand)
    {
        frontCol = _frontCol;
        hand = _hand;
        pAnimScript = GetComponent<PlayerAnimationScript>();
    }

  
    public PlayerAnimState CtrlAction()
    {
        if (isGrab)
        {
            if (currGrabObj.tag == "Extinguisher")
            {
                //extinguishd�ִϸ��̼� ��� �� extinguisher�� �۵� ��ũ��Ʈ ����
                return PlayerAnimState.Hold;
            }
            else
            {
                return PlayerAnimState.None;
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
                    switch (collider.tag)
                    {
                        case "Table":
                            TableScript tableScr = collider.GetComponent<TableScript>();
                            GameObject cuttingBoard = null;

                            if (tableScr.GetRaisedObject().tag == "CuttingBoard")
                            {
                                cuttingBoard = tableScr.GetRaisedObject();
                                if (tableScr.GetTopRaisedObj().tag == "Ingredient")
                                {
                                    if (tableScr.GetTopRaisedObj().GetComponent<IngredientScript>().GetIsChopped())
                                    {
                                        return PlayerAnimState.None;
                                    }
                                    else
                                    {
                                        tableScr.GetRaisedObject().GetComponent<CuttingBoardScript>().SetCutting(true);
                                        currCuttingBoard = cuttingBoard;
                                        currCuttingBoard.GetComponent<CuttingBoardScript>().AddCutter();
                                        isChop = true;
                                        return PlayerAnimState.Chop;
                                        //���¸� Chopping���� �����ֱ�
                                        //���Ĺ��� Chop �־��ֱ�
                                        //chop
                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }
        return PlayerAnimState.None;
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
                                                if(currGrabObj.GetComponent<IngredientScript>().GetIsChopped())
                                                {
                                                    /*tableScr.GetRaisedObject().GetComponent<PotScript>().PutIngredient();*/
                                                    Debug.Log("��Ḧ �ܿ� ����");
                                                }
                                            }
                                            return false;
                                        case "Plate":
                                            Debug.Log("��Ḧ ���ÿ� ����");

                                            return false;
                                        case "CuttingBoard":
                                            if (currGrabObj.tag == "Ingredient")
                                            {
                                                tableScr.GetRaisedObject().GetComponent
                                                    <RaisedObjectScript>().RaisObject(currGrabObj);
                                                Release();
                                                return true;
                                            }
                                            Debug.Log("��Ḧ ������ ����");
                                            return false;
                                    }
                                    //���� ���̺� �÷������� Pot�̳� Plate��� true �����ϰ� ��� �ۼ�
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

    public bool GetChopIsDone()
    {
        if (isChop) // ��� �ִ� ���̶��
        {
            if (currCuttingBoard == null)
                Debug.LogError("��� �������� �ұ��ϰ� cuttingboard�� null�Դϴ�");

            var boardScr = currCuttingBoard.GetComponent<CuttingBoardScript>();

            if (!CollisionCheck.Check(frontCol.bounds, currCuttingBoard))
            {
                boardScr.RemoveCutter();
                currCuttingBoard = null;
                isChop = false;
                return true;
                //�̰��� �ۼ��ؾ���
            }
            if (boardScr.GetRaisedObject().GetComponent<IngredientScript>().GetIsChopped())
            {
                boardScr.RemoveCutter();
                currCuttingBoard = null;
                isChop = false;
                return true;
            }
            return false;
        }
        else
        {
            return true;
        }
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

}
