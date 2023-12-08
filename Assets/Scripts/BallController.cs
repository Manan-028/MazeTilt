using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Check if there's any touch input
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Convert touch position to world space
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));

            // Set the Y position to 0 to keep the movement in the horizontal plane
            touchPosition.y = 0f;

            // Calculate the direction to move in
            Vector3 direction = (touchPosition - transform.position).normalized;

            // Apply force in the direction of the calculated movement
            GetComponent<Rigidbody>().AddForce(new Vector3(direction.x, 0f, direction.z) * speed);
        }
    }
}
