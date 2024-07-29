using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeUIMoveEffectScript : MonoBehaviour
{
    float moveSpeed = 2000.0f;
    bool isMove = false;

    public void UiMoveEvent(Vector3 targetPos)
    {
        StartCoroutine(UILeftMove(targetPos));
    }

    private IEnumerator UILeftMove(Vector3 targetPos)
    {
        isMove = true;

        while (Vector3.Distance(transform.position,targetPos) > 0.01f)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMove = false;
    }
}