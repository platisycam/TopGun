using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordDate {
    private string name;
    private string score;
    private string date;

    public RecordDate() {
    }

    public RecordDate(string name, string score) {
        this.name = name;
        this.score = score;
        this.date = System.DateTime.Now.ToString();
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public string Date
    {
        get
        {
            return date;
        }

        set
        {
            date = value;
        }
    }
}
