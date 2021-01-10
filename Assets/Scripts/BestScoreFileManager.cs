using System;
using System.IO;
using UnityEngine;


// create save files, for this game it's just saving one int and that could be done simpler using PlayerPrefs, but I 
// wanted to try this way which is probably better when you want to save a lot of things?
public class BestScoreFileManager : MonoBehaviour
{
    
    public static BestScoreFileManager Instance { get; private set; }

    public int Score { get; private set; }

    private string fileName;
    
    void Awake()
    {
        Instance = this;
        fileName = Path.Combine(Application.persistentDataPath, "fb_save");
        
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

    public void DeleteSave()
    {
        Score = 0;
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Open)))
        {
            writer.Write(0);
        }
    }
    
}