using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeOpenScript : MonoBehaviour
{
    float moveSpeed = 1000.0f;

    public IEnumerator OpenRecipeCoroutine()
    {
        RectTransform mRectTr = this.gameObject.GetComponent<RectTransform>();

        Vector3 targetPos = new Vector3(mRectTr.localPosition.x, -70, mRectTr.localPosition.z);

        while (Vector3.Distance(mRectTr.localPosition, targetPos) > 0.01f)
        {
            mRectTr.localPosition = Vector3.MoveTowards(mRectTr.localPosition, targetPos, moveSpeed * Time.deltaTime);

            yield return null;
        }

        mRectTr.localPosition = targetPos;
    }
}