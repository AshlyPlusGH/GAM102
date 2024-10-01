using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public Vector3 offset; // Offset position of the camera relative to the target

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
    }
}
