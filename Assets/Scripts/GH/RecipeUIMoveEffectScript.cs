using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RecipeUIMoveEffectScript : MonoBehaviour
{
    public float moveSpeed = 3000.0f;
    bool isMove = false;


    public void UiMoveEvent(Vector3 targetPos)
    {
        StartCoroutine(UIMoveToTargetWithRotation(targetPos));
    }

    private IEnumerator UIMoveToTargetWithRotation(Vector3 targetPos)
    {
        RectTransform mRectTr = this.GetComponent<RectTransform>();
        mRectTr.rotation = Quaternion.Euler(0, 0, 10.0f);

        float totalDistance = Vector3.Distance(transform.position, targetPos);

        while(Vector3.Distance(mRectTr.position,targetPos) > 0.01f)
        {
            float distance = Vector3.Distance(mRectTr.position, targetPos);

            float distanceTraveled = totalDistance - distance;

            mRectTr.position = Vector3.MoveTowards(mRectTr.position, targetPos, moveSpeed * Time.deltaTime);

            float rotationZ = Mathf.Lerp(10.0f, 0.0f, (distanceTraveled / totalDistance));

            mRectTr.rotation = Quaternion.Euler(0, 0, rotationZ);

            yield return null;
        }

        mRectTr.position = targetPos;
        mRectTr.rotation = Quaternion.Euler(0, 0, 0);
    }
}