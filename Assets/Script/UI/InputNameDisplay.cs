using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNameDisplay : MonoBehaviour {
    GameObject sceneCtrl;
    public GameObject playernameObj;
    GameObject scoreObj;
    string playername ="";
    string score = "";
    // Use this for initialization


    void Start () {
        sceneCtrl = GameObject.Find("SystemObject");
        scoreObj = GameObject.Find("Score");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayScore(string score) {
        this.score = score;
        if (scoreObj != null) {
            scoreObj.GetComponent<Text>().text = "Score: " + score;
        }
    }

    public void Submit() {
        playername = playernameObj.GetComponent<Text>().text;
        if (playername.Equals("")) {
            playername = "Player 1";
        }
        sceneCtrl.GetComponent<AccessRecord>().WriteRecord(this.playername, this.score);
        sceneCtrl.GetComponent<SceneCtrl>().InitMisson();
    }


}
