using UnityEngine;

public class RandomAI_Move : MonoBehaviour
{
    public float moveSpeed = 1f; // The distance to move the object each time
    public float minInterval = 1f;  // Minimum time interval between movements
    public float maxInterval = 3f;  // Maximum time interval between movements

    private Vector3 randomDirection;
    private float nextMoveTime;

    private void Start()
    {
        // Start the first movement
        SetNextMoveTime();
    }

    private void Update()
    {
        // Check if it's time to move the object
        if (Time.time >= nextMoveTime)
        {
            // Move the object
            MoveObject();
            // Set the next time the object will move
            SetNextMoveTime();
        }
    }

    private void SetNextMoveTime()
    {
        // Randomly choose a time between the minInterval and maxInterval
        nextMoveTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    private void MoveObject()
    {
        transform.Translate(0, moveSpeed, 0);
    }
}
