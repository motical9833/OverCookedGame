using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeOrderControllerScript : MonoBehaviour
{

    public GameObject gameManager;

    List<GameObject> prefabs;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");

        string name = SceneManager.GetActiveScene().name;
        
        if(gameManager == null)
        {
            return;
        }

        List<string> recipes = gameManager.GetComponent<CookingSchedulerScript>().GetOrdersData(name);
        
    }

    void Update()
    {

    }
}
