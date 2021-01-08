using System;
using System.IO;
using UnityEngine;

public class BestScoreFileManager : MonoBehaviour
{
    
    public static BestScoreFileManager Instance { get; private set; }

    public int Score { get; private set; }

    private string fileName;
    
    void Awake()
    {
        Instance = this;
        fileName = Path.Combine(Application.persistentDataPath, "fb_save");

        Debug.Log(fileName);
        if (File.Exists(fileName))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                Score = reader.ReadInt32();
            }
        }
        else
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(0);
            }
            Score = 0;
        }
        
    }

    public void SaveScore(int score)
    {
        Score = score;
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Open)))
        {
            writer.Write(score);
        }
    }
    
}