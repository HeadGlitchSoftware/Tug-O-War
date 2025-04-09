using UnityEngine;
using TMPro;
using UnityEngine.Android;  // Import the TextMeshPro namespace

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text countdownText;  // Reference to your TMP_Text component

    [SerializeField]
    private float timerDuration = 10f;  // Default duration in seconds

    [SerializeField]
    private string tickSoundEffect;

    [SerializeField]
    private bool playing;

    private float currentTime;
    private float previousTime;

    // Start is called before the first frame update
    void Start(){
        SetTimerDuration(timerDuration);
        UpdateTimer();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer(){
        if (currentTime > 0 & playing)
        {
            previousTime = currentTime;
            currentTime -= Time.deltaTime;  // Decrease time
            UpdateDisplay();
        }
    }

    // Method to update the text display with the current countdown time
    private void UpdateDisplay(){
        // Convert the time to minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        int previousSeconds = Mathf.FloorToInt(previousTime % 60);

        if (seconds != previousSeconds){
            TimerSoundEffect();
        }
        countdownText.text = string.Format("{0}:{1:D2}", minutes, seconds);
    }

    private void TimerSoundEffect(){
        AudioManager.Instance.PlaySFX(tickSoundEffect);
    }

    public void SetTimerDuration(float newDuration){
        timerDuration = newDuration;
        currentTime = timerDuration;
        UpdateDisplay();
    }

    public void ResetTimer(){
        SetTimerDuration(timerDuration);
    }

    public void Playing(bool value){
        playing = value;
    }
}
