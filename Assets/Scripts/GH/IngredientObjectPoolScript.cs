using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngredientObjectPoolScript : MonoBehaviour
{
    private GameObject prefab;
    private int poolSize = 20;
    private Queue<GameObject> pool;
    private string resourceName = "";

    void Start()
    {
        pool = new Queue<GameObject>();

        resourceName = gameObject.name + "/" + gameObject.name;

        prefab = Resources.Load("3D/Food_Objects/" + resourceName) as GameObject;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            BoxCollider col = obj.AddComponent<BoxCollider>();
            obj.tag = "Ingridient";
            col.size = new Vector3(0.007f, 0.007f, 0.007f);
            col.center = new Vector3(0.0f, 0.004f,0.0f);
            col.isTrigger = false;
            
            obj.transform.parent = this.gameObject.transform;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.parent = null;
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            GetIngredientPoolObject();
        }
    }

    public GameObject GetIngredientPoolObject()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            if(obj == null)
            {
                Debug.LogError("obj로 Null이 반환되었습니다");
                return null;
            }
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(true);
            if (obj == null)
            {
                Debug.LogError("obj로 Null이 반환되었습니다");
                return null;
            }
            return obj;
        }
    }

    public void PushIngredientPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
