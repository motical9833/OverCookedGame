using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Order
{
    public string dishName { get; set; }
    public float timeLimit { get; set; }


    public Order(string name, float time)
    {
        dishName = name;
        timeLimit = time;
    }
}

public class OrderQueueManager
{
    public List<Queue<Order>> ListQueue { get; set; }

    public OrderQueueManager(int numberOfQueues)
    {
        ListQueue = new List<Queue<Order>>();
        for (int i = 0; i < numberOfQueues; i++)
        {
            ListQueue.Add(new Queue<Order>());
        }
    }

    public void AddOrder(int queueIndex, string name, float time)
    {
        if (queueIndex >= 0 && queueIndex < ListQueue.Count)
        {
            var order = new Order(name, time);
            ListQueue[queueIndex].Enqueue(order);
        }
    }

    public Order GetPeekOrder(int queueIndex)
    {
        if(queueIndex >= 0 && queueIndex < ListQueue.Count)
        {
            if (ListQueue[queueIndex].Count > 0)
            {
                var order = ListQueue[queueIndex].Peek();
                 
                return order;
            }
        }
    }
}*/