using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [SerializeField] List<string> lines;

    public void AddLines(List<string> lines)
    {
        this.lines = lines;
    }

    public List<string> Lines { get { return lines; } }
}
