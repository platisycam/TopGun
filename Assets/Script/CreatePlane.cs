using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlane : MonoBehaviour {
    float createTime = 0f;
    float minX = -7.2f;
    float maxX = 7.2f;
    float y = 5.3f;
    float x;
    GameObject enemy;
    GameObject hero;
    GameObject sceneCtrl;
    // Use this for initialization
    void Start () {
        enemy = (GameObject)Resources.Load("Prefab/EnemyPlane");
        hero = (GameObject)Resources.Load("Prefab/HeroPlane");
        sceneCtrl = GameObject.Find("SystemObject");
        CreateHero();
    }
	
	// Update is called once per frame
	void Update () {
        if (sceneCtrl != null && sceneCtrl.GetComponent<SceneCtrl>().IsRunning)
        {
            JudgeCreateEnemy();
        }


    }

    private void JudgeCreateEnemy() {
        if (Time.time - createTime > 2f)
        {
            CreateOneEnemy();
        }
    }

    private void CreateOneEnemy() {
        x = Random.Range(minX, maxX);
        GameObject enemyPlane = Instantiate(enemy);
        enemyPlane.transform.position = new Vector3(x, y, 0f);
        createTime = Time.time;
    }

    public void CreateHero() {
        GameObject heroPlane = Instantiate(hero);
        heroPlane.transform.position = new Vector3(0f, -5f, 0f);
        sceneCtrl.GetComponent<SceneCtrl>().IsRunning = true;
    }
}
