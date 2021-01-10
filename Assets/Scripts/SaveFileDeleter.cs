using UnityEngine;

public class SaveFileDeleter : MonoBehaviour
{
    
    public void DeleteSave()
    {
        BestScoreFileManager.Instance.DeleteSave();
    }
}