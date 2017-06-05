using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCtrl : MonoBehaviour {
    float move = 0.05f;
    int shootGap = 20;
    int frameTime = 0;
    GameObject ammo;
	// Use this for initialization
	void Start () {
        ammo = (GameObject)Resources.Load("Prefab/Ammo");
    }
	
	// Update is called once per frame
	void Update () {
        //move action
        if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < 7.2f)
        {
            this.transform.position += new Vector3(move, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > -7.2f)
        {
            this.transform.position -= new Vector3(move, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow) && this.transform.position.y < 5.3f)
        {
            this.transform.position += new Vector3(0f, move, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow) && this.transform.position.y > -5.3f)
        {
            this.transform.position -= new Vector3(0f, move, 0f);
        }

        //shoot action
        if (Input.GetKey(KeyCode.LeftControl))
        {
            frameTime++;
            if (frameTime == shootGap)
            {
                Shoot();
                frameTime = 0;
            }
        }
        else
        {
            frameTime = 0;
        }
    }


    private void Shoot() {
        Instantiate(ammo, transform.position, transform.rotation);
    }

    public void OnShoot()
    {
        GameObject.Find("SystemObject").GetComponent<SceneCtrl>().HeroFall();
        Destroy(this.gameObject);

    }
}
