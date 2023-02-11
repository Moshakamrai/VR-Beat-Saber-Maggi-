using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public StringBuilder sb = new StringBuilder();

    private void Start()
    {
        record();
    }
    public void record()
    {
        sb.AppendLine(PlayerPrefs.GetString("name") + ';' + PlayerPrefs.GetString("age") + ";" + PlayerPrefs.GetString("phone") + ";" + PlayerPrefs.GetString("email") + PlayerPrefs.GetInt("score"));
        SaveToFile(sb.ToString());
    }
    public void SaveToFile(string content)
    {
        // Use the CSV generation from before
        //var content = ToCSV();

        // The target file path e.g.
        //var folder = Application.streamingAssetsPath;
        var folder = "C:\\Maggi";

        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);


        var filePath = Path.Combine(folder, "export.csv");

        using (var writer = new StreamWriter(filePath, false))
        {
            writer.Write(content);
        }
    }
}
