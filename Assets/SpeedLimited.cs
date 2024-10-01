using UnityEngine;

public class SpeedLimited : MonoBehaviour
{

    public Vector2 SpeedLimit;
    private Rigidbody2D rb;
    public bool isGlobalSpeedLimited = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rb.velocity;
        if (velocity.magnitude > Global.SpeedLimit)
        {
            velocity = velocity.normalized * Global.SpeedLimit;
            rb.velocity = velocity;
        }
    }
}
