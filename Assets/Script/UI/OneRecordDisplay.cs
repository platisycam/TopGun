using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneRecordDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetOneRecord(string seq, string playername, string score, string date) {
        this.transform.FindChild("Seq").GetComponent<Text>().text = seq;
        this.transform.FindChild("Playername").GetComponent<Text>().text = playername;
        this.transform.FindChild("Score").GetComponent<Text>().text = score;
        this.transform.FindChild("Date").GetComponent<Text>().text = date;
    }
}
