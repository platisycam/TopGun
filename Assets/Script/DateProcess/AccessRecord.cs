using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class AccessRecord : MonoBehaviour {
    XmlDocument xml;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public XmlDocument InitXml(TextAsset txt) {
        xml = new XmlDocument();
        xml.LoadXml(txt.text);
        return xml;
    }

    public List<RecordDate> GetRecordListFromXml() {
        XmlDocument xml = ReadFile();
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
        return recordList;
    }

    public void WriteRecord(string name, string score) {
        xml = ReadFile();
        RecordDate newRecord = new RecordDate(name, score);
        SortXml(xml, newRecord);
    }

    public void SortXml(XmlDocument xml, RecordDate newRecord) {
        XmlNode recordNode = xml.SelectSingleNode("record");
        XmlNodeList playerNodes = recordNode.ChildNodes;
        int count = playerNodes.Count;
        bool isAdded = false;
        for (int i = 0; i < count; i++)
        {
            if (playerNodes[0].ChildNodes[1].InnerText == "") {
                playerNodes[0].ChildNodes[0].InnerText = newRecord.Name;
                playerNodes[0].ChildNodes[1].InnerText = newRecord.Score;
                playerNodes[0].ChildNodes[2].InnerText = newRecord.Date;
                isAdded = true;
                break;
            }

            if (int.Parse(newRecord.Score) > int.Parse(playerNodes[i].ChildNodes[1].InnerText))
            {
                XmlNode playerNode = playerNodes[i].Clone();
                playerNode.ChildNodes[0].InnerText = newRecord.Name;
                playerNode.ChildNodes[1].InnerText = newRecord.Score;
                playerNode.ChildNodes[2].InnerText = newRecord.Date;

                if (i <= 9)
                {
                    recordNode.InsertBefore(playerNode, playerNodes[i]);
                }
                else {
                    recordNode.ReplaceChild(playerNode, playerNodes[i]);
                }
                isAdded = true;
                break;
            }
        }
        if (!isAdded && count < 10) {
            XmlNode playerNode = playerNodes[count - 1].Clone();
            playerNode.ChildNodes[0].InnerText = newRecord.Name;
            playerNode.ChildNodes[1].InnerText = newRecord.Score;
            playerNode.ChildNodes[2].InnerText = newRecord.Date;
            recordNode.InsertAfter(playerNode, playerNodes[count - 1]);
        }
        xml.Save("C:/record.xml");
    }

    public bool IsRecord(int score) {
        xml = ReadFile();
        XmlNode recordNode = xml.SelectSingleNode("record");
        XmlNodeList playerNodes = recordNode.ChildNodes;
        int count = playerNodes.Count;
        bool isRecord = false;
        for (int i = 0; i < count; i++)
        {
            if (playerNodes[0].ChildNodes[1].InnerText == "" || score >= int.Parse(playerNodes[i].ChildNodes[1].InnerText) || count < 10)
            {
                isRecord = true;
                break;
            }
        }
        return isRecord;
    }



    private XmlDocument ReadFile() {
        xml = new XmlDocument();
        try
        {
            xml.Load("C:/record.xml");
        }
        catch (FileNotFoundException)
        {
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
        }
        return xml;
    }
}
