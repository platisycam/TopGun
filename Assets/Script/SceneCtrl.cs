using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour {
    private int lifeNum = 3;
    private int score = 0; 
	// Use this for initialization
	void Start () {
        GameObject.Find("Canvas/ScoreText").GetComponent<ScoreDisplay>().ShowScore(score);
        GameObject.Find("Canvas/LifeText").GetComponent<LifeDisplay>().ShowLife(lifeNum);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HeroFall() {
        lifeNum--;
        GameObject.Find("Canvas/LifeText").GetComponent<LifeDisplay>().ShowLife(lifeNum);
    }

    public void EnemyFall() {
        score += 50;
        GameObject.Find("Canvas/ScoreText").GetComponent<ScoreDisplay>().ShowScore(score);
    }

}
