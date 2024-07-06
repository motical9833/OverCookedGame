using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RecipeBookController : MonoBehaviour
{
    Transform[] childs = new Transform[5];
    public Vector3[] cameraPos;
    public Vector3[] cameraRot;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            childs[i] = gameObject.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StageSelectScene");
        }
    }
}
