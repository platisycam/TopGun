using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                item = Instantiate(prefab, new Vector3(0, y - 40, 0), Quaternion.identity);
                item.transform.SetParent(content);
                item.GetComponent<OneRecordDisplay>().SetOneRecord(
                    (i + 1).ToString(), records[i].Name, records[i].Score, records[i].Date);
            }
        }
    }
}
