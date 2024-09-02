using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageSummaryScript : MonoBehaviour
{
    GameObject audioManager;
    GameObject gameManager;

    public TextMeshProUGUI[] textMeshProUGUIs;

    void Start()
    {
        textMeshProUGUIs = new TextMeshProUGUI[3];

        for (int i = 0; i < textMeshProUGUIs.Length; i++)
        {
            textMeshProUGUIs[i] = this.transform.GetChild(2).GetChild(i).gameObject.GetComponent<TextMeshProUGUI>();
        }

        gameManager = GameObject.FindWithTag("GameManager");
        audioManager = GameObject.FindWithTag("AudioManager");

        //SetSummaryTextUI(6, 17, 0);

        if (!audioManager || !gameManager)
        {
            Debug.Log("매니저를 찾을 수 없음!");
            return;
        }
    }

    public void SetSummaryTextUI(int orderDelivered, int tip, int failedCount)
    {
        textMeshProUGUIs[0].text = (orderDelivered + " x " + 20 + " = " + orderDelivered * 20).ToString();
        textMeshProUGUIs[1].text = tip.ToString();
        textMeshProUGUIs[2].text = (failedCount + " x " + 10 + " = " + failedCount * 10).ToString();
    }
}
