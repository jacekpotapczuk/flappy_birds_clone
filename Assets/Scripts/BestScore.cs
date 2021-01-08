using System;
using System.IO;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    
    public static BestScore Instance { get; private set; }

    public int Score { get; set; }

    private string fileName;
    void Awake()
    {
        Instance = this;
        fileName = Application.persistentDataPath + "/fb_save";
        

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