using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCtrl : MonoBehaviour {
    float move = 0.1f;
    GameObject sceneCtrl;
    // Use this for initialization
    void Start () {
        Invoke("DestroyAmmo", 5f);
        sceneCtrl = GameObject.Find("SystemObject");
    }

    // Update is called once per frame
    void Update () {
        if (sceneCtrl != null && sceneCtrl.GetComponent<SceneCtrl>().IsRunning)
        {
            MoveAmmo();
        }
    }

    void OnTriggerEnter2D(Collider2D plane)
    {
        if ("Enemy".Equals(plane.tag))
        {
            plane.GetComponent<EnemyPlaneCtrl>().OnShoot();
            Destroy(this.gameObject);
        }
    }

    private void DestroyAmmo() {
        DestroyImmediate(this.gameObject);
    }

    private void MoveAmmo() {
        this.transform.position += new Vector3(0f, move, 0f);
    }
}
