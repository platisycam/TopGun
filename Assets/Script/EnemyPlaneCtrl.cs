using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneCtrl : MonoBehaviour {
    float move = -0.03f;
    int shootGap = 100;
    int frameTime = 0;
    GameObject ammo;
    GameObject sceneCtrl;
    // Use this for initialization
    void Start () {
        ammo = (GameObject)Resources.Load("Prefab/EnemyAmmo");
        Invoke("DestroyEnemy", 10f);
        sceneCtrl = GameObject.Find("SystemObject");
    }
	
	// Update is called once per frame
	void Update () {
        if (sceneCtrl != null && sceneCtrl.GetComponent<SceneCtrl>().IsRunning)
        {
            MoveEnemyPlane();
            ShootAction();
        }

    }

    void OnTriggerEnter2D(Collider2D plane)
    {
        if ("Hero".Equals(plane.tag))
        {
            plane.GetComponent<PlaneCtrl>().OnShoot();
            Destroy(this.gameObject);
        }
    }

    private void MoveEnemyPlane() {
        this.transform.position += new Vector3(0f, move, 0f);
    }

    private void ShootAction() {
        frameTime++;
        if (frameTime == shootGap)
        {
            Shoot();
            frameTime = 0;
        }
    }

    private void Shoot() {
        Instantiate(ammo, transform.position, transform.rotation);
    }

    private void DestroyEnemy()
    {
        DestroyImmediate(this.gameObject);
    }

    public void OnShoot()
    {
        GameObject.Find("SystemObject").GetComponent<SceneCtrl>().EnemyFall();
        Destroy(this.gameObject);
    }

}
