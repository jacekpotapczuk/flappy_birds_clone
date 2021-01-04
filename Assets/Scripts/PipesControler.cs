using UnityEngine;


public class PipesControler : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)]
    private float scrollSpeed = 1f;
    
    
    [SerializeField] private Transform[] pipes;

    [SerializeField] private Player player;
    
    private const float leftCutoff = -3.5f;
    private const float rightCutoff = 3.5f; // TODO: usunac jezeli okaze sie useless
    private float pipeDistance = 4f; // TODO: skalowanie z poziomem trudnosci, pamietac o zachowaniu odpowiednich odl przy zmiane w runtime

    private bool[] didPipeScore;
    
    private float heightMax = 2f;

    private float heightMin = -3f;
    
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
            if (pipe.position.x <= -3f && !didPipeScore[i])
            {
                player.AddScore();
                didPipeScore[i] = true;
            }
                
            
            Vector3 pos = pipe.position;
            pos.x -= scrollSpeed * Time.deltaTime;

            if (pos.x < leftCutoff)
            {
                pos.x += 2f * pipeDistance;
                pos.y = Random.Range(heightMin, heightMax);
                didPipeScore[i] = false;
            }
                
            pipe.position = pos;
        }
    }

    public void Restart()
    {
        pipes[0].position = new Vector3(3.5f, 0f, 0f); // init first pipe
        
        // initialize rest of pipes to keep correct distance from the first pipe
        for (int i = 1; i < pipes.Length; i++)
        {
            Vector3 pos = pipes[i].position;
            pos.x = pipes[i - 1].position.x + pipeDistance;
            pipes[i].position = pos;
        }
    }
}