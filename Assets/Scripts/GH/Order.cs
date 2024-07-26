using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    private string orderName;
    
    public string OrderName
    {
        get { return orderName; }

        set { orderName = OrderName; } 
    }
    private float timeLimit;

    public float TimeLimit
    {
        get { return timeLimit; }

        set { timeLimit = TimeLimit; }
    }
    
    public Order(string name, float time)
    {
        orderName = name;
        timeLimit = time;
    }
}
