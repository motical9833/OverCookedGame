using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectUIScript : MonoBehaviour
{
    public Transform pivotObjTr;
    public GameObject smallUIObject;
    public GameObject largeUIObject;

    private Coroutine scaleCoroutine;
    private Vector3 targetVector = new Vector3(0.0f, 6.0f, 1.0f);
    private Vector3 originVector;

    void Start()
    {
        pivotObjTr = this.gameObject.transform.GetChild(0).GetChild(0);
        smallUIObject = pivotObjTr.GetChild(0).gameObject;
        largeUIObject = pivotObjTr.GetChild(1).gameObject;
        originVector = pivotObjTr.localScale;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
            }

            scaleCoroutine =  StartCoroutine(ScaleUI(pivotObjTr, originVector, targetVector, 0.2f,false,true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
            }

            scaleCoroutine = StartCoroutine(ScaleUI(pivotObjTr, originVector, targetVector, 0.2f, true, false));
        }
    }

    //UI의 크기를 시간에 흐름에 따라 변경하는 코루틴
    private IEnumerator LerpCoroutine(Transform uiObj, Vector3 fromScale, Vector3 toScale, float duration)
    {
        float currentTime = 0f;

        while (currentTime < duration)
        {
            uiObj.localScale = Vector3.Lerp(fromScale, toScale, currentTime / duration);
            currentTime += Time.deltaTime;
            yield return null;
        }

        uiObj.localScale = toScale;
    }

    private IEnumerator ScaleUI(Transform uiObj, Vector3 fromScale, Vector3 toScale, float duration, bool activeSmallUI, bool activeLargeUI)
    {
        // UI확대 코루틴
        yield return LerpCoroutine(uiObj, fromScale, toScale, duration);

        smallUIObject.SetActive(activeSmallUI);
        largeUIObject.SetActive(activeLargeUI);

        //UI 축소 코루틴
        yield return LerpCoroutine(uiObj, toScale, fromScale, duration);
    }
}
