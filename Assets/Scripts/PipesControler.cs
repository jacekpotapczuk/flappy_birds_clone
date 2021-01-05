using UnityEngine;


public class PipesControler : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    private float scrollSpeed = 1f;
    
    
    [SerializeField] private Transform[] pipes;

    [SerializeField] private Player player;
    
    private const float leftCutoff = -5f;
    private const float rightCutoff = 3.5f; // TODO: usunac jezeli okaze sie useless
    private float pipeDistance = 4f; // TODO: skalowanie z poziomem trudnosci, pamietac o zachowaniu odpowiednich odl przy zmiane w runtime

    private bool[] didPipeScore;
    
    private float heightMax = 2.2f;

    private float heightMin = -2.2f;
    
    private void Start()
    {
        didPipeScore = new bool[pipes.Length];
        Restart();
    }
    
    private void Update()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            Transform pipe = pipes[i];
            if (pipe.localPosition.x <= -4.5f && !didPipeScore[i])
            {
                player.AddScore();
                didPipeScore[i] = true;
            }
                
            
            Vector3 pos = pipe.localPosition;
            pos.x -= scrollSpeed * Time.deltaTime;

            if (pos.x < leftCutoff)
            {
                pos.x += 2f * pipeDistance;
                pos.y = Random.Range(heightMin, heightMax);
                didPipeScore[i] = false;
            }
                
            pipe.localPosition = pos;
        }
    }

    public void Restart()
    {
        pipes[0].localPosition = new Vector3(3.5f, 0f, 0f); // init first pipe
        
        // initialize rest of pipes to keep correct distance from the first pipe
        for (int i = 1; i < pipes.Length; i++)
        {
            Vector3 pos = pipes[i].localPosition;
            pos.x = pipes[i - 1].localPosition.x + pipeDistance;
            pipes[i].localPosition = pos;
        }
    }
}