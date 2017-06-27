using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour {
    private int lifeNum = 3;
    private int score = 0;
    private bool isRunning = false;
    GameObject scoreDisplay;
    GameObject lifeDisplay;
	// Use this for initialization
	void Start () {
        scoreDisplay = GameObject.Find("Canvas/ScoreText");
        lifeDisplay = GameObject.Find("Canvas/LifeText");
        //显示分数
        scoreDisplay.GetComponent<ScoreDisplay>().ShowScore(score);
        lifeDisplay.GetComponent<LifeDisplay>().ShowLife(lifeNum);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HeroFall() {
        lifeNum--;
        lifeDisplay.GetComponent<LifeDisplay>().ShowLife(lifeNum);
    }

    public void EnemyFall() {
        score += 50;
        scoreDisplay.GetComponent<ScoreDisplay>().ShowScore(score);
    }

}
