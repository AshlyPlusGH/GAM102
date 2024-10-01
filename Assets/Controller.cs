using System.Reflection.Emit;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float thrustForce = 10f;
    public float rotationSpeed = 100f;
    public float offsetAngle = 0f; // Offset angle in degrees
    public float linearDrag = 1f; // Linear drag to slow down the spaceship
    public float angularDrag = 1f; // Angular drag to slow down rotation
    public float minVelocity = 0.1f; // Minimum velocity to apply drag
    public float minAngularVelocity = 0.1f;
    public float SpeedLimit;
    private Rigidbody2D rb;

    //OutputTesting
    public float CurrentVelocityMagnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;
        CurrentVelocityMagnitude = rb.velocity.magnitude;
        // Apply thrust
        if (Input.GetKey(KeyCode.W))
        {
            float totalAngle = transform.eulerAngles.z + offsetAngle;
            Vector2 thrustDirection = new Vector2(Mathf.Cos(totalAngle * Mathf.Deg2Rad), Mathf.Sin(totalAngle * Mathf.Deg2Rad));
            rb.AddForce(thrustDirection * thrustForce);
        }

        // Rotate left
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(rotationSpeed * Time.deltaTime);
        }

        // Rotate right
        if (Input.GetKey(KeyCode.E))
        {
            rb.AddTorque(-rotationSpeed * Time.deltaTime);
        }

        // Apply angular drag to reduce rotational momentum
        rb.angularVelocity *= (1 - angularDrag * Time.deltaTime);

        // Apply linear drag if S key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            rb.drag = linearDrag;
        }
        else
        {
            rb.drag = 0f;
        }

        // Set drag to zero if velocity is small enough
        if (rb.velocity.magnitude < minVelocity)
        {
            rb.velocity = Vector2.zero;
        }
        if (!Input.GetKey(KeyCode.E)&&!Input.GetKey(KeyCode.Q)){
            if (0f-minAngularVelocity < rb.angularVelocity && rb.angularVelocity< minAngularVelocity)
            {
                rb.angularVelocity = 0f;
            }
        }
        
        if (velocity.magnitude > SpeedLimit)
        {
            velocity = velocity.normalized * SpeedLimit;
            rb.velocity = velocity;
        }
    }
}