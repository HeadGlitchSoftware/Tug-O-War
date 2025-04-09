using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text countdownText;  // Reference to your TMP_Text component
    [SerializeField]
    private float timerDuration = 10f;  // Default duration in seconds
    private float currentTime;  // Current time left on the countdown

    // Start is called before the first frame update
    void Start()
    {
        SetTimerDuration(timerDuration);
        UpdateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer(){
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;  // Decrease time
            UpdateDisplay();
        }
        else
        {
            currentTime = 0;
        }
    }

    // Method to update the text display with the current countdown time
    void UpdateDisplay()
    {
        // Convert the time to minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        countdownText.text = string.Format("{0}:{1:D2}", minutes, seconds);
    }

    // Optional: Method to reset the timer to a new duration
    public void SetTimerDuration(float newDuration)
    {
        timerDuration = newDuration;
        currentTime = timerDuration;
        UpdateDisplay();
    }
}
