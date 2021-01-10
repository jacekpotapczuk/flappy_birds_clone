using UnityEngine;

public class Pipe : MonoBehaviour
{
    
    [SerializeField] private float heightMin = -2.2f;
    [SerializeField] private float heightMax = 2.2f;
    
    [SerializeField] private Transform downPart; 
    [SerializeField] private Transform upperPart;

    [SerializeField] private float scoringX = -4.5f;
    [SerializeField] private float resetX = 4.5f;
    
    [SerializeField] private Score score;
    
    private bool didScore = false;
    private bool didReset = false;

    void Update()
    {
        if (transform.localPosition.x <= scoringX && !didScore)
        {
            score.AddPoint();
            didScore = true;
            didReset = false;
        }

        if (transform.localPosition.x >= resetX && !didReset)
        {
            float newY = Random.Range(heightMin, heightMax);
            Vector3 pos = transform.localPosition;
            pos.y = newY;
            transform.localPosition = pos;
            didReset = true;
            didScore = false;
        }
    }
    
}