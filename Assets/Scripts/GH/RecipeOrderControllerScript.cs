using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeOrderControllerScript : MonoBehaviour
{
    public GameObject gameManager;
    public List<GameObject> recipeList;

    public int maxOrderCnt = 5;
    int orderCnt = 0;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");

        string name = SceneManager.GetActiveScene().name;

        if (gameManager == null)
        {
            return;
        }

        List<string> recipes = gameManager.GetComponent<CookingSchedulerScript>().GetOrdersData(name);

        if (recipes != null && recipes.Count > 0)
        {
            SpawnRecipe(recipes);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            FoodOrderComesIn(new Vector3(100.0f, 86.0f, 0));
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            ServeFood("Soup_Onion");
        }
    }

    private void SpawnRecipe(List<string> recipes)
    {
        Transform parentTr = this.gameObject.GetComponent<Transform>().GetChild(0);

        for (int i = 0; i < recipes.Count; i++)
        {
            string recipeName = recipes[i];

            GameObject prefab = Resources.Load<GameObject>("GHPrefabs/Foods/" + recipeName);

            if (prefab != null)
            {
                for (int j = 0; j < 5; j++)
                {
                    GameObject ob = Instantiate(prefab, parentTr.position, Quaternion.identity, parentTr);
                    ob.name = recipeName;
                    ob.SetActive(false);
                    recipeList.Add(ob);
                }
            }
        }
    }

    public void FoodOrderComesIn(Vector3 targetPos)
    {
        if (orderCnt >= maxOrderCnt)
        {
            return;
        }

        orderCnt++;

        for (int i = 0; i < recipeList.Count; i++)
        {
            if (recipeList[i].activeSelf == false)
            {
                recipeList[i].SetActive(true);
                recipeList[i].GetComponent<RecipeUIMoveEffectScript>().UiMoveEvent(targetPos);
                break;
            }
        }
    }

    public void ServeFood(string name)
    {
        if (orderCnt <= 0)
            return;

        GameObject servefood = null;

        for (int i = 0; i < recipeList.Count; i++)
        {
            if (recipeList[i].activeSelf == false)
                continue;

            if (recipeList[i].name != name)
                continue;

            if (servefood == null)
            {
                servefood = recipeList[i];
                continue;
            }

            if (servefood.GetComponent<OrderUIScript>().GetCurrentTime() > recipeList[i].GetComponent<OrderUIScript>().GetCurrentTime())
            {
                servefood = recipeList[i];
            }
        }

        servefood.GetComponent<OrderUIScript>().ResetTimer();
        servefood.GetComponent<Transform>().position = servefood.GetComponent<Transform>().parent.position;
        servefood.SetActive(false);

        orderCnt--;
    }
}
