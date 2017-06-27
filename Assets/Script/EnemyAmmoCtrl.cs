using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoCtrl : MonoBehaviour {
    float move = -0.05f;
    GameObject sceneCtrl;
    // Use this for initialization
    void Start () {
        DestroyAmmo();
        sceneCtrl = GameObject.Find("SystemObject");
    }
	
	// Update is called once per frame
	void Update () {
        if (sceneCtrl != null && sceneCtrl.GetComponent<SceneCtrl>().IsRunning) {
            MoveAmmo();
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


    private void DestroyAmmo()
    {
        Destroy(this.gameObject, 5f);
    }

    private void MoveAmmo()
    {
        this.transform.position += new Vector3(0f, move, 0f);
    }
}
