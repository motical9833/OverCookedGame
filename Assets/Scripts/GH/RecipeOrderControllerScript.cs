using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeOrderControllerScript : MonoBehaviour
{
    public class Recipe
    {
        GameObject recipeUIObject;
        public GameObject RecipeUIObject
        {
            get { return recipeUIObject; }
            private set { recipeUIObject = value; } 
        }

        int orderNumber;
        public int OrderNumber
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }

        public Recipe(GameObject recipe, int number)
        {
            recipeUIObject = recipe;
            orderNumber = number;
        }

        public Recipe(Recipe recipe)
        {
            recipeUIObject = recipe.recipeUIObject;
            orderNumber = recipe.orderNumber;
        }
    }



    //public GameObject gameManager;

    public List<Recipe> recipeClass = new List<Recipe>();

    public Queue<Recipe> recipeQueue = new Queue<Recipe>();

    public int maxOrderCnt = 5;
    int orderCnt = 0;
    bool isFull = false;

    void Start()
    {
        GameObject gameManager = GameObject.FindWithTag("GameManager");

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
            FoodOrderComesIn(new Vector3(90.0f, 1030.0f, 0));
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            ServeFood("Soup_Onion");
            OrderUIRelocation();
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

                    Recipe recipe = new Recipe(ob, 0);
                    recipeQueue.Enqueue(recipe);
                }
            }
        }
    }

    public void FoodOrderComesIn(Vector3 targetPos)
    {
        if (isFull)
        {
            return;
        }

        targetPos.x += 210 * orderCnt;

        Recipe recipe = recipeQueue.Dequeue();

        recipeClass.Add(recipe);
        recipe.RecipeUIObject.SetActive(true);
        recipe.RecipeUIObject.GetComponent<RecipeUIMoveEffectScript>().UiMoveEvent(targetPos);
        recipe.OrderNumber = recipeClass.Count;

        orderCnt++;

        if (orderCnt >= maxOrderCnt)
        {
            isFull = true;
        }

    }

    public void ServeFood(string name)
    {
        if (orderCnt <= 0)
            return;

        Recipe servefood = null;

        for (int i = 0; i < recipeClass.Count; i++)
        {
            if (recipeClass[i].RecipeUIObject.name != name)
                continue;

            if (servefood == null || servefood.RecipeUIObject.GetComponent<OrderUIScript>().GetCurrentTime() > recipeClass[i].RecipeUIObject.GetComponent<OrderUIScript>().GetCurrentTime())
            {
                servefood = recipeClass[i];
            }
        }

        if(servefood == null)
        {
            Debug.Log("해당 음식이 없음!");
            return;
        }

        servefood.OrderNumber = 0;
        servefood.RecipeUIObject.GetComponent<OrderUIScript>().ResetTimer();
        servefood.RecipeUIObject.GetComponent<RecipeUIMoveEffectScript>().ResetUIPos();
        servefood.RecipeUIObject.SetActive(false);

        recipeQueue.Enqueue(servefood);
        recipeClass.Remove(servefood);

        orderCnt--;
        isFull = false;
    }


    public bool IsFull()
    {
        return isFull;
    }

    public int GetOrderCount()
    {
        return orderCnt;
    }


    private void OrderUIRelocation()
    {
        int count = 0;

        for (int i = 0; i < recipeClass.Count; i++)
        {
            if (recipeClass[i].RecipeUIObject.activeSelf)
            {
                count++;

                recipeClass[i].RecipeUIObject.GetComponent<RecipeUIMoveEffectScript>().PositionUIElements(new Vector3(90.0f, 1030.0f, 0), i);

                if(count == orderCnt)
                    break;
            }
        }
    }
}