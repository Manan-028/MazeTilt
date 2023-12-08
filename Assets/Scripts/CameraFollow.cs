using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Drag and drop the ball GameObject here
    public Vector3 offset = new Vector3(0f, 5f, -7f); // Adjust the offset as needed

    void Update()
    {
        if (target != null)
        {
            // Set the camera's position to follow the player with the specified offset
            transform.position = target.position + offset;
        }
    }
}
