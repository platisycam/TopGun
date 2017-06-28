using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowMenu() {
        this.gameObject.SetActive(true);
    }

    public void BlankMenu()
    {
        this.gameObject.SetActive(false);
    }
}
