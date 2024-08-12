using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class RaisedObjectScript : NetworkBehaviour
{
    public GameObject raisedObj;
    public void RaisObject(GameObject _raisedObj)
    {
        raisedObj = _raisedObj;
        raisedObj.transform.SetParent(transform);
        Vector3 raisedObjPos = new Vector3(transform.position.x,
                                            transform.position.y + 0.005f,
                                            transform.position.z);
        raisedObj.transform.position = raisedObjPos;
    }

    public GameObject GetRaisedObject()
    {
        return raisedObj;
    }

    public bool IsRaised()
    {
        if (raisedObj == null)
            return false;
        else
            return true;
    }

    public void Release()
    {
        raisedObj = null;
    }

    public GameObject GetTopRaisedObj()
    {
        GameObject current = raisedObj;
        while (current != null)
        {
            if(!current.GetComponent<RaisedObjectScript>())
            {
                return current;
            }
            if (current.GetComponent<RaisedObjectScript>().GetRaisedObject() == null)
            {
                return current;  //���� ���� �ִ� ������Ʈ�� �÷��а� �����Ƿ� null���� ���
            }
            current = current.GetComponent<RaisedObjectScript>().GetRaisedObject();
        }

        return this.gameObject; // ���� �ִ� ���� ����
    }
}
