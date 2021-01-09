using UnityEngine;

public class Pipe : MonoBehaviour
{
    // TODO: sprawdzic co public, co private
    public float heightMin = -2.2f;
    public float heightMax = 2.2f;
    
    public Transform downPart; // TODO: wykorzystac to przy poziomie trudnosci
    public Transform upperPart;

    public float scoringX = -4.5f;
    public float resetX = 4.5f;

    
    public Score score;
    
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