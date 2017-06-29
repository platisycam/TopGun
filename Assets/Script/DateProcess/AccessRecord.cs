using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class AccessRecord : MonoBehaviour {
    TextAsset txt;
    XmlDocument xml;
	// Use this for initialization
	void Start () {
        txt = Resources.Load("Date/Record", typeof(TextAsset)) as TextAsset;
        xml = new XmlDocument();
        xml = InitXml(txt);
        PrintRecord(xml);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public XmlDocument InitXml(TextAsset txt) {
        xml = new XmlDocument();
        xml.LoadXml(txt.text);
        return xml;
    }

    public void PrintRecord(XmlDocument xml) {
        XmlNode recordNode = xml.SelectSingleNode("record");
        XmlNodeList playerNodes = recordNode.ChildNodes;
        int count = playerNodes.Count;
        List<RecordDate> recordList = new List<RecordDate>();
        RecordDate record;
        for (int i = 0; i < count; i++) {
            record = new RecordDate();
            record.Name = playerNodes[i].ChildNodes[0].InnerText;
            record.Score = playerNodes[i].ChildNodes[1].InnerText;
            record.Date = playerNodes[i].ChildNodes[2].InnerText;
            recordList.Add(record);
        }

        for (int i = 0; i < count; i++) {
            Debug.Log(recordList[i].Name);
            Debug.Log(recordList[i].Score);
            Debug.Log(recordList[i].Date);
        }
    }
}
