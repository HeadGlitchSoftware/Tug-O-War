using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    //[Header("Scene Components")]
    [SerializeField]
    private TimerController timerController;

    [SerializeField]
    private RopeManager ropeManager;

    [SerializeField]
    private Animator countdownAnimation;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);  
    }

    public void StartGameSequence()
    {
        timerController.Playing(true);
        ropeManager.Play();
    }

    public void ResetGame()
    {
        //Reset and pause the timer
        timerController.ResetTimer();
        timerController.Playing(false);
        
        //Reset and pause rope assets
        ropeManager.Reset();
        ropeManager.Pause();
        
        //Reset Animation
        countdownAnimation.SetTrigger("Restart Animation");
    }
}
