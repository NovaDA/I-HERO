using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreensController : MonoBehaviour {


    GameObject nextLevelItem;
    ScoreManager score;
    public Text name;
    bool scoreHigh;
    int ScreenIndex;    
    /// not sure if ineed this global
    //public GameObject nextScene;

	void Start ()
    {
        nextLevelItem = GameObject.Find("ItemToNextTitle");
        nextLevelItem.SetActive(false);
        score = FindObjectOfType<ScoreManager>();

       // nextScene.SetActive(false);
	}

	public void NextScreen()
    {
        HighScoreControl();
        ChangeScreens();
        Debug.Log(ScreenIndex);
    }

    private void HighScoreControl()
    {
        if(score.ScoreIsHighInTable())
        {
            ScreenIndex += 1;
        }
        else
        {
            ScreenIndex += 2;
        }
    }

    private void ChangeScreens()
    { 
        GameObject[] gameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject go in gameObjects)
        {
            if (ScreenIndex == 1 && go.gameObject.name == "UIKeyBoard")     /// activate
            {
                if (!go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(true);
                }
            }

            if (ScreenIndex == 1 && go.gameObject.name == "Score Animation") /// Disactivate
            {
                if (go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(false);
                }
            }

            if (ScreenIndex == 1 && go.gameObject.name == "LeadBoard") /// activate
            {
                if (!go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(true);
                }
            }

            if (ScreenIndex == 2 && go.gameObject.name == "Score Animation")
            {
                if (go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(false);
                }
            }

            if (ScreenIndex == 2 && go.gameObject.name == "LeadBoard") /// activate
            {
                if (!go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(true);   
                }
            }

            if (ScreenIndex == 2 && go.gameObject.name == "GameManager") /// activate
            {
                if (!go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(true);

                }
            }


            if (ScreenIndex == 2 && go.gameObject.name == "ItemToNextTitle") /// activate
            {
                if (!go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(true);

                }
            }

            if (ScreenIndex == 2 && go.gameObject.name == "UIKeyBoard") /// Disactivate
            {
                if (go.gameObject.activeSelf)
                {
                    go.gameObject.SetActive(false);
                }
            }
        }
    }

    public void SendScore()
    {
        if (name.text == "INPUT NAME" || name.text.Length <= 0)
        {
            Debug.Log("Empty Space");
        }
        else
        {
            GameObject.FindObjectOfType<ScoreManager>().SubmitScoreToTable(name.text);
            NextScreen();
        }
    }
}
