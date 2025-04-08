using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text countdownText;  // Reference to your TMP_Text component
    public float timerDuration = 10f;  // Default duration in seconds
    private float currentTime;  // Current time left on the countdown

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the timer with the set duration
        currentTime = timerDuration;
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;  // Decrease time
            UpdateTimerDisplay();
        }
        else
        {
            currentTime = 0;
            // Timer has finished, you can do something here if needed (e.g., trigger an event)
        }
    }

    // Method to update the text display with the current countdown time
    void UpdateTimerDisplay()
    {
        // Convert the time to minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Format minutes as a single digit, and seconds as two digits (e.g., "3:05")
        countdownText.text = string.Format("{0}:{1:D2}", minutes, seconds);
    }

    // Optional: Method to reset the timer to a new duration
    public void SetTimerDuration(float newDuration)
    {
        timerDuration = newDuration;
        currentTime = timerDuration;
        UpdateTimerDisplay();
    }
}
