using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowGameOver(bool isGaming)
    {
        if (isGaming) {
            this.GetComponent<Text>().text = "";
        } else {
            this.GetComponent<Text>().text = "Game Over !";
        }
    }
}
