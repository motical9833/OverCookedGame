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
    private bool isSelectMenu = false;


    void Start()
    {
        mySelectArrow = this.GetComponent<Transform>().GetChild(0).gameObject;
    }

    void Update()
    {
        if(isSelectMenu)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && state != State.QUIT)
            {
                state++;
                mySelectArrow.transform.localPosition += new Vector3(0.0f, -0.004f, 0.0f);

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && state != State.CAMPAIGN)
            {
                state--;
                mySelectArrow.transform.localPosition += new Vector3(0.0f, 0.004f, 0.0f);
            }

            switch (state)
            {
                case State.CAMPAIGN:
                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        SceneManager.LoadScene("StageSelectScene");
                        isSelectMenu = false;
                    }
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

    public void ActivateUIArrow()
    {
        isSelectMenu = true;
    }

    public void DeactivateUIArrow()
    {
        isSelectMenu = false;
    }
}
