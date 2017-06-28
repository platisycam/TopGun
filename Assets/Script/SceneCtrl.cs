using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour {
    private int lifeNum;
    private int score;
    private bool isRunning;
    private bool isGaming;
    GameObject scoreDisplay;
    GameObject lifeDisplay;
    GameObject gameOverDsiplay;
	// Use this for initialization
	void Start () {
        scoreDisplay = GameObject.Find("Canvas/ScoreText");
        lifeDisplay = GameObject.Find("Canvas/LifeText");
        gameOverDsiplay = GameObject.Find("Canvas/GameOverText");
        //显示分数
        ResetDisplay();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (isGaming)
            {
                IsRunning = !IsRunning;
            }
            else {
                InitMisson();
            }
        }
	}

    public void HeroFall() {
        lifeNum--;
        if (lifeNum >= 0)
        {
            isGaming = true;
        }
        else {
            isGaming = false;
        }
        if (isGaming)
        {
            lifeDisplay.GetComponent<LifeDisplay>().ShowLife(lifeNum);
            Invoke("ResetHero", 1f);
        }
        else {
            IsRunning = false;
            gameOverDsiplay.GetComponent<GameOverDisplay>().ShowGameOver(isGaming);
        }
    }

    private void ResetHero() {
        this.GetComponent<CreatePlane>().CreateHero();
    }

    public void EnemyFall() {
        score += 50;
        scoreDisplay.GetComponent<ScoreDisplay>().ShowScore(score);
    }

    private void ResetDisplay() {
        lifeNum = 2;
        score = 0;
        isRunning = false;
        isGaming = true;
        scoreDisplay.GetComponent<ScoreDisplay>().ShowScore(score);
        lifeDisplay.GetComponent<LifeDisplay>().ShowLife(lifeNum);
        gameOverDsiplay.GetComponent<GameOverDisplay>().ShowGameOver(isGaming);

    }

    private void InitMisson()
    {
        ResetDisplay();
        GameObject[] ammos = GameObject.FindGameObjectsWithTag("Ammo");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0, j = ammos.Length; i < j; i++) {
            Destroy(ammos[i]);
        }
        for (int i = 0, j = enemys.Length; i < j; i++)
        {
            Destroy(enemys[i]);
        }
        ResetHero();
    }

    public bool IsRunning{
        get{
            return isRunning;
        }

        set{
            this.isRunning = value;
        }
    }

    public bool IsGaming {
        get
        {
            return isGaming;
        }

        set
        {
            this.isGaming = value;
        }
    }


}
