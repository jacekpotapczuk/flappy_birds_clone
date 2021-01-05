using UnityEngine;


// Scroll given objects and teleport when outside of the screen, it only affects x coordinate
public class RepeatScroll : MonoBehaviour
{
    [SerializeField, Range(-10, 10)] private float startX = 0f;
    [SerializeField, Range(0f, 10f)] private float scrollSpeed = 2.5f;
    [SerializeField, Range(-10f, 0f)] private float leftCutoff = -5f;
    [SerializeField, Range(1f, 10f)] private float distance = 4f;
    [SerializeField] private Transform[] objects;

    private void Start()
    {
        Debug.Assert(objects.Length >= 2, "error, objects.Length >= 2. RepeatScroll needs atleast " +
                                          "two objects.");

        ResetPosition();
    }
    
    private void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 pos = objects[i].localPosition;
            pos.x -= scrollSpeed * Time.deltaTime;
            objects[i].localPosition = pos;
            
            if (pos.x < leftCutoff)
                pos.x += objects.Length * distance;
            
            objects[i].localPosition = pos;
        }
    }

    public void ResetPosition()
    {
        // objects return to initial position. Only x coordinate is affected!
        // first one is moved to startX
        // second one is at startX + distance
        // ...
        Vector3 pos = objects[0].localPosition;
        pos.x = startX;
        objects[0].localPosition = pos; // init first object

        // initialize rest of objects to keep correct distance from the first one
        for (int i = 1; i < objects.Length; i++)
        {
            pos = objects[i].localPosition;
            pos.x = objects[i - 1].localPosition.x + distance;
            objects[i].localPosition = pos;
        }
    }
}