using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class AccessRecord : MonoBehaviour {
    TextAsset txt;
    XmlDocument xml;
    string recordPath;
    // Use this for initialization
    void Start () {
        //recordPath = Application.dataPath + "/Date/Record";
        //txt = Resources.Load("Date/Record", typeof(TextAsset)) as TextAsset;
        //xml = new XmlDocument();
        //xml = InitXml(txt);
        WriteRecord("a","100");
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

    public XmlDocument CreateRecord() {
        xml = new XmlDocument();
        XmlElement record = xml.CreateElement("record");
        xml.AppendChild(record);
        XmlElement player = xml.CreateElement("player");
        record.AppendChild(player);
        XmlElement name = xml.CreateElement("name");
        XmlElement score = xml.CreateElement("score");
        XmlElement date = xml.CreateElement("date");
        player.AppendChild(name);
        name.InnerText = "";
        player.AppendChild(score);
        score.InnerText = "";
        player.AppendChild(date);
        date.InnerText = "";
        PrintRecord(xml);
        return xml;
    }

    public void WriteRecord(string name, string score) {
        xml = new XmlDocument();
        try {
            xml.Load("C:/record.xml");
        }
        catch (FileNotFoundException e) {
            xml = CreateRecord();
        }
        RecordDate newRecord = new RecordDate(name, score);
        SortXml(xml, newRecord);
    }

    public void SortXml(XmlDocument xml, RecordDate newRecord) {
        XmlNode recordNode = xml.SelectSingleNode("record");
        XmlNodeList playerNodes = recordNode.ChildNodes;
        int count = playerNodes.Count;
        List<RecordDate> recordList = new List<RecordDate>();
        RecordDate record;
        for (int i = 0; i < count; i++)
        {
            record = new RecordDate();
            record.Name = playerNodes[i].ChildNodes[0].InnerText;
            record.Score = playerNodes[i].ChildNodes[1].InnerText;
            record.Date = playerNodes[i].ChildNodes[2].InnerText;
            recordList.Add(record);
        }

    }


}
