using UnityEngine;

public class MoveOnSpace : MonoBehaviour
{
    // Speed at which the object will move on the Y-axis
    public float moveSpeed = 1f;

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Move the GameObject along the Y-axis by the specified moveSpeed
            transform.Translate(0, -moveSpeed, 0);
        }
    }
}
