using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordDisplay : MonoBehaviour {
    GameObject prefab;
    GameObject item;
    Transform content;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayRecoreds(List<RecordDate> records) {
        int count = records.Count;
        int y = 0;
        prefab = (GameObject)Resources.Load("Prefab/Record");
        content = this.transform.FindChild("Viewport").FindChild("Content");
        if (count > 0) {
            for (int i = 0; i < count; i++) {
                item = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
                y -= 40;
                item.transform.SetParent(content);
                item.transform.localPosition = new Vector3(0f, y, 0f);
                item.GetComponent<OneRecordDisplay>().SetOneRecord(
                    (i + 1).ToString(), records[i].Name, records[i].Score, records[i].Date);
            }
        }
    }
}
