using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyboard : MonoBehaviour {

    // Use this for initialization
    string word = "";
    int wordCounts;
    int IndexScreens = 0;
    public Text name = null;


    ScoreManager score;    /// no ned for this anymore

    private void Start()
    {
   
    }

    public void InsertLetter(string letter)
    {
        if(wordCounts < 3)
        {
            word = word + letter;
            name.text = word;
            wordCounts++;
        }
        
    }

    public void DeleteLetter()
    {
        if(word.Length > 0)
        {
            string NEWWORD = word.Remove(word.Length - 1, 1);
            word = NEWWORD;
            name.text = word;
            wordCounts--;
        }
    }

    //public void SendScore()
    //{
        
    //    if(name.text == "INPUT NAME" || name.text.Length <= 0)
    //    {
    //        Debug.Log("Empty Space");
    //    }
    //    else
    //    {
    //        GameObject.FindObjectOfType<ScoreManager>().SubmitScoreToTable(name.text);
    //        Next();
    //    }

       
    //}

    //public void Next()
    //{
    //    IndexScreens++;
    //    ChangeScreens();
        

    //}

    //public int GetScreensIndex()   //noy need of this
    //{
    //    return IndexScreens;
    //}

    //private void ChangeScreens()
    //{
    //    //if(!score.ScoreIsHighInTable())
    //    //{
    //    //    IndexScreens++;
    //    //}

    //    Debug.Log(IndexScreens);
    //    GameObject[] gameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
    //    foreach (GameObject go in gameObjects)
    //    {

    //        if (IndexScreens == 1 && go.gameObject.name == "UIKeyBoard")     /// activate
    //        {
    //            if (!go.gameObject.activeSelf)
    //            {
    //                go.gameObject.SetActive(true);
                    
    //            }
    //        }

    //        if (IndexScreens == 1 && go.gameObject.name == "Score Animation") /// Disactivate
    //        {
    //            if (go.gameObject.activeSelf)
    //            {
    //                go.gameObject.SetActive(false);
    //            }
    //        }

    //        if (IndexScreens == 1 && go.gameObject.name == "LeadBoard") /// activate
    //        {
    //            if (!go.gameObject.activeSelf)
    //            {
    //                go.gameObject.SetActive(true);
                   
    //            }
    //        }

    //        if (IndexScreens == 2 && go.gameObject.name == "UIKeyBoard") /// Disactivate
    //        {
    //            if (go.gameObject.activeSelf)
    //            {
    //                go.gameObject.SetActive(false);
    //            }
    //        }

    //    }
    //}

    /// add function to submit the name 

    #region parts that i don't really need at the moment
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
    #endregion
}
