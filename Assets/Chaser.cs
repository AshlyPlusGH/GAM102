using UnityEngine;

public class ChaseTarget : MonoBehaviour
{
    public Transform target; // The target GameObject to chase
    public float speed = 5f; // Speed at which the GameObject will chase
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Set the Rigidbody's velocity to move towards the target
            rb.velocity = direction * speed;
        }
    }
}
