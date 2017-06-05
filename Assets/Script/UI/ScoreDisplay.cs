using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Text>().text = "Score: ";

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowScore(int score) {
        this.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
