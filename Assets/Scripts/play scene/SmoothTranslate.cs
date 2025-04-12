using UnityEngine;

public class SmoothTranslate : MonoBehaviour
{
    [SerializeField] private Transform targetPosition; // The target position to move towards
    [SerializeField] private float baseSpeed = 1f; // Base speed for movement

    private void Update()
    {
        if (targetPosition != null)
        {
            // Calculate the distance between the current position and the target position
            float distance = Vector3.Distance(transform.position, targetPosition.position);
            
            // Increase speed as the distance increases (distance-based acceleration)
            float speed = baseSpeed * distance;

            // Smoothly move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
        }
    }
}
