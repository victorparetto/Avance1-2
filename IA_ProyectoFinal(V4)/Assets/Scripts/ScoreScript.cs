using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text scoreT;
    public int actualScore;

    public Text timerT;
    public float timerScore;

	void Start () {
		
	}
	
	void Update () {
       timerScore += Time.deltaTime;

        scoreT.text = "Score: " + actualScore;
        timerT.text = "" + (int)timerScore;
	}
}
