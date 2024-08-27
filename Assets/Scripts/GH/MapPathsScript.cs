using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class MapPathsScript : MonoBehaviour
{
    public float changeDuration = 1.0f;

    public void ActivePath(int procedure)
    {
        GameObject pathParent = this.transform.GetChild(procedure).gameObject;

        pathParent.SetActive(true);
    }

    public void UnLockPath(int procedure)
    {
        Transform pathsTr = this.transform.GetChild(procedure);
        pathsTr.gameObject.SetActive(true);

        for (int i = 0; i < pathsTr.childCount; i++)
        {
            StartCoroutine(PathScaleController(pathsTr.GetChild(i),changeDuration));
        }
    }

    IEnumerator PathScaleController(Transform pathTr,float duration)
    {
        Vector3 initialScale = pathTr.localScale;

        float elapsedTime = 0.0f;

        while (elapsedTime < changeDuration)
        {
            pathTr.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.one;
    }
}
