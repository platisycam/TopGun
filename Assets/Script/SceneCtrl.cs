using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl : MonoBehaviour {
    private int lifeNum;
    private int score;
    //private bool isRunning;
    private bool isGaming;
    GameObject scoreDisplay;
    GameObject lifeDisplay;
    GameObject gameOverDsiplay;
    GameObject menu;
    GameObject inputName;
	// Use this for initialization
	void Start () {
        scoreDisplay = GameObject.Find("Canvas/ScoreText");
        lifeDisplay = GameObject.Find("Canvas/LifeText");
        gameOverDsiplay = GameObject.Find("Canvas/GameOverText");
        menu = GameObject.Find("Canvas/Menu");
        inputName = GameObject.Find("Canvas/InputName");
        menu.SetActive(false);
        inputName.SetActive(false);
        //显示分数
        ResetDisplay();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (isGaming)
            {
                if (Time.timeScale == 1)
                {
                    menu.GetComponent<MenuCtrl>().ShowMenu();
                    Time.timeScale = 0;
                }
                else {
                    menu.GetComponent<MenuCtrl>().BlankMenu();
                    Time.timeScale = 1;
                }
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
            Time.timeScale = 0;
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
        //isRunning = false;
        Time.timeScale = 0;
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

    //public bool IsRunning{
    //    get{
    //        return isRunning;
    //    }

    //    set{
    //        this.isRunning = value;
    //    }
    //}

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
