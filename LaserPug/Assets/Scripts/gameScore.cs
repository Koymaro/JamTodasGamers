using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameScore : MonoBehaviour
{
    Text scoreTextUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }

        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }
	// Use this for initialization
	void Start ()
    {
        //get the text ui component of this gameobject
        scoreTextUI = GetComponent<Text>();
	}

    //update the score text ui
    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000}", score);
        scoreTextUI.text = scoreStr;
    }
}
