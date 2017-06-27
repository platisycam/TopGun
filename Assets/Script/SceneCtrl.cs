using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour {
    private int lifeNum = 2;
    private int score = 0;
    private bool isRunning = false;
    GameObject scoreDisplay;
    GameObject lifeDisplay;
    GameObject gameOverDsiplay;
	// Use this for initialization
	void Start () {
        scoreDisplay = GameObject.Find("Canvas/ScoreText");
        lifeDisplay = GameObject.Find("Canvas/LifeText");
        gameOverDsiplay = GameObject.Find("Canvas/GameOverText");
        //显示分数
        scoreDisplay.GetComponent<ScoreDisplay>().ShowScore(score);
        lifeDisplay.GetComponent<LifeDisplay>().ShowLife(lifeNum);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HeroFall() {
        lifeNum--;
        if (lifeNum >= 0)
        {
            lifeDisplay.GetComponent<LifeDisplay>().ShowLife(lifeNum);
            Invoke("ResetHero", 1f);
        }
        else {
            IsRunning = false;
            gameOverDsiplay.GetComponent<GameOverDisplay>().ShowGameOver();
        }
    }

    private void ResetHero() {
        this.GetComponent<CreatePlane>().CreateHero();
    }

    public void EnemyFall() {
        score += 50;
        scoreDisplay.GetComponent<ScoreDisplay>().ShowScore(score);
    }

    public bool IsRunning{
        get{
            return isRunning;
        }

        set{
            this.isRunning = value;
        }
    }


}
