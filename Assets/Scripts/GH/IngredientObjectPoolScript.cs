using System.Collections;
using System.Collections.Generic;
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
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(true);
            return obj;
        }
    }

    public void PushIngredientPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
