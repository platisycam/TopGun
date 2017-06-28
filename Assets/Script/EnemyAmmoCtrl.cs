﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAmmoCtrl : MonoBehaviour {
    float move = -0.05f;
    // Use this for initialization
    void Start () {
        Invoke("DestroyAmmo", 5f);
        this.tag = "Ammo";
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1) {
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
        DestroyImmediate(this.gameObject);
    }

    private void MoveAmmo()
    {
        this.transform.position += new Vector3(0f, move, 0f);
    }
}
