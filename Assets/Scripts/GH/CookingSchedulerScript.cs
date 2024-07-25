using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public string orderName { get; set; }
    public float timeLimit { get;set; }

    public Order(string name ,float time)
    {
        orderName = name;
        timeLimit = time;
    }

}

public class CookingSchedulerScript : MonoBehaviour
{
    public List<Order> order = new List<Order>();


    void Start()
    {

    }

    void Update()
    {
        if (order.Count > 0)
        {
            for (int i = order.Count-1; i >= 0; i--)
            {
                order[i].timeLimit -= Time.deltaTime;

                if (order[i].timeLimit <= 0)
                {
                    order.RemoveAt(i);
                }
            }
        }

    }

    public void SetOrder(Order orderData)
    {
        order.Add(orderData);
    }

    Order GetOrder(string str)
    {
        if(order.Count > 0)
        {
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i].orderName == str)
                {
                    return order[i];
                }
            }
        }

        return null;
    }

    public void MakeDish(string dishName)
    {
        if (order.Count > 0)
        {
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i].orderName == dishName)
                {
                    //Á¡¼ö È¹µæ ·ÎÁ÷ ÀÛ¼º
                    break;
                }
            }
        }

        return;
    }
}
