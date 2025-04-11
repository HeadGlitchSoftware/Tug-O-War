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

    [SerializeField]
    private WinCheck winCheck;

    private float currentTime;
    private float previousTime;

    void Start(){
        SetTimerDuration(timerDuration);
        UpdateTimer();
    }

    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer(){
        if (currentTime >= 1 & playing)
        {
            previousTime = currentTime;
            currentTime -= Time.deltaTime;
            UpdateDisplay();
        }
        else if (currentTime < 1){
            Debug.Log("Time's Up!");
            currentTime = 0;
            winCheck.OnTimeOut();
        }
    }

    private void UpdateDisplay(){
        // Convert the time to minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        int previousSeconds = Mathf.FloorToInt(previousTime % 60);

        if (seconds != previousSeconds & playing){
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
