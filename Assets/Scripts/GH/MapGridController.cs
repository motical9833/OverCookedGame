using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGridController : MonoBehaviour
{
    bool isInitialize = false;

    [System.Serializable]
    public class MapObjects
    {
        public List<GameObject> objects = new List<GameObject>();
    }

    public MapObjects[] objectGrop = new MapObjects[5];
    public List<bool> isOpenHex = new List<bool>();
    GameObject tiles;
    public GameObject gameManager;

    public void InitializeObjectGroups()
    {
        if (this.transform.childCount == 0 || this.transform.GetChild(0).childCount == 0)
        {
            Debug.Log("��ũ��Ʈ�� �߸��� ��ġ�� ����");
            return;
        }

        gameManager = GameObject.FindWithTag("GameManager");

        if (gameManager == null)
        {
            Debug.Log("���� �Ŵ����� �������� ����!");
            return;
        }

        tiles = this.transform.GetChild(0).GetChild(2).gameObject;

        for (int i = 0; i < objectGrop.Length; i++)
        {
            objectGrop[i] = new MapObjects();
        }

        //���� Ȯ���� �� ���� �ʿ� [3]��
        for (int i = 0; i < 3; i++)
        {
            Transform gropTr = tiles.transform.GetChild(0).GetChild(i);
            int count = gropTr.childCount;

            for (int j = 0; j < count; j++)
            {
                objectGrop[i].objects.Add(gropTr.GetChild(j).gameObject);
            }
        }

        InitializeStageHex();

        isInitialize = true;
    }

    void InitializeStageHex()
    {
        isOpenHex = gameManager.GetComponent<StageSaveLoadScript>().GetAllisAble();

        for (int i = 0;i < isOpenHex.Count;i++)
        {
            if (isOpenHex[i])
            {
                for (int j = 0; j < objectGrop[i].objects.Count; j++)
                {
                    objectGrop[i].objects[j].transform.localRotation = Quaternion.identity;
                }
            }
        }
    }

    public void OpenStage()
    {

    }
}
