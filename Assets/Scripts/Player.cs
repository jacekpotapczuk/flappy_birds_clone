using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)]
    private float clickForce = 5f;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Physics2D.gravity = new Vector3(0f, -20f, 0f);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localPosition = new Vector3(-2f, 1.5f, 0f);
        }
        else if (Input.anyKeyDown)
        {
            rigidbody.velocity = new Vector2(0f, clickForce);
        }
    }
}