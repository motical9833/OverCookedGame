using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeOpenScript : MonoBehaviour
{
    public void OpenRecipeEvent()
    {
        StartCoroutine(OpenRecipeCoroutine());
    }

    private void Start()
    {
        RectTransform mRectTr = this.gameObject.GetComponent<RectTransform>();

        Debug.Log(mRectTr.localPosition);
    }


    IEnumerator OpenRecipeCoroutine()
    {
        RectTransform mRectTr = this.gameObject.GetComponent<RectTransform>();


        yield return null;
    }
}
