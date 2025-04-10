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
    private AnimationAudioManager animationAudioManager;

    private bool playing = false;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        animationAudioManager = countdownAnimation.GetComponent<AnimationAudioManager>();  
    }

    public void StartGame(){
        playing = true;
        ResumeGame();
    }

    public void ResumeGame()
    {
        countdownAnimation.enabled = true; 
        animationAudioManager.ResumeAll();

        if (playing){
        timerController.Playing(true);
        ropeManager.Play();
        }
    }

    public void ResetGame()
    {
        playing = false;
        //Reset scene elements
        timerController.ResetTimer();
        ropeManager.Reset();
        FreezeGame();
        //Reset Animation
        countdownAnimation.SetTrigger("Restart Animation");
    }

    public void PauseGame(){
        countdownAnimation.enabled = false;
        animationAudioManager.PauseAll();
        
        if (playing){
            FreezeGame();
        }
    }

    private void FreezeGame(){
        timerController.Playing(false);
        ropeManager.Pause();
    }
}
