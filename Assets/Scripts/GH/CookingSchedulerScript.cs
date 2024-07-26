using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingSchedulerScript : MonoBehaviour
{
    public List<Order> order = new List<Order>();

    void Update()
    {
        if (order.Count > 0)
        {
            for (int i = order.Count-1; i >= 0; i--)
            {
                order[i].TimeLimit -= Time.deltaTime;

                if (order[i].TimeLimit <= 0)
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
                if (order[i].OrderName == str)
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
                if (order[i].OrderName == dishName)
                {
                    //Á¡¼ö È¹µæ ·ÎÁ÷ ÀÛ¼º
                    break;
                }
            }
        }
        return;
    }
}
