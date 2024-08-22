using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSelectUIScript : MonoBehaviour
{
    private enum State
    { 
        CAMPAIGN,
        VERSUS,
        MORSEL,
        FESTIVE,
        OPTIONS,
        CREDITS,
        QUIT,
    }

    State state = State.CAMPAIGN;

    GameObject mySelectArrow;
    public bool isSelectMenu = false;
    public float moveDistance = 0.004f;
    public float coolTIme;

    void Start()
    {
        mySelectArrow = this.GetComponent<Transform>().GetChild(0).gameObject;
    }

    void Update()
    {
        if(isSelectMenu)
        {
            coolTIme += Time.deltaTime;

            HandleInput();
            HandleSelection();

            if(Input.GetKeyDown(KeyCode.Escape) && coolTIme >= 1.0f)
            {
                DeActivateUIArrow();
                coolTIme = 0.0f;
            }
        }
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow) && state != State.QUIT)
        {
            ChangeState(1);
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && state != State.CAMPAIGN)
        {
            ChangeState(-1);
        }
    }

    private void ChangeState(int direction)
    {
        state += direction;
        float moveY = direction * -moveDistance;
        mySelectArrow.transform.localPosition += new Vector3(0.0f, moveY, 0.0f);
    }

    private void HandleSelection()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch (state)
            {
                case State.CAMPAIGN:
                    LoadScene("StageSelectScene");
                    break;
                case State.VERSUS:
                    break;
                case State.MORSEL:
                    break;
                case State.FESTIVE:
                    break;
                case State.OPTIONS:
                    break;
                case State.CREDITS:
                    break;
                case State.QUIT:
                    break;
                default:
                    break;
            }
        }
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        isSelectMenu = false;
    }

    public void ActivateUIArrow()
    {
        isSelectMenu = true;
    }

    public void DeActivateUIArrow()
    {
        isSelectMenu = false;
    }
}
