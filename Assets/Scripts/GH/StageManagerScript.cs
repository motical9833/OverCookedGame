using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerScript : MonoBehaviour
{
    public float currentTime = 0.0f;

    bool isStart = false;

    GameObject orderPanal;

    void Start()
    {
        orderPanal = GameObject.FindWithTag("MainCanvas");

        if(orderPanal == null)
        {
            Debug.LogError("orderPanal이 비어있음!! 태그 확인필요...");
            return;
        }

        StartCoroutine(GameStart());
    }

    void Update()
    {
        if(!isStart)
            return;

        currentTime += Time.deltaTime;

        if(currentTime >= 20.0f || orderPanal.GetComponent<RecipeOrderControllerScript>().GetOrderCount() == 0)
        {
            orderPanal.transform.GetChild(0).GetComponent<RecipeOrderControllerScript>().FoodOrderComesIn(new Vector3(90.0f, 1030.0f, 0));
            currentTime = 0.0f;
        }
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(3);

        orderPanal.transform.GetChild(0).GetComponent<RecipeOrderControllerScript>().FoodOrderComesIn(new Vector3(90.0f, 1030.0f, 0));

        isStart = true;
    }

    public void ServingDishes(string orderName)
    {

    }
}