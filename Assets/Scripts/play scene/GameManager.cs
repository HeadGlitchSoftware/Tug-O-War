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

    [SerializeField]
    private ScoreManager scoreManager;

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

    public void ResumeGame()
    {
        timerController.Playing(true);
        ropeManager.Play();
    }

    public void ResetGame()
    {
        //Reset scene elements
        timerController.ResetTimer();
        ropeManager.Reset();

        //Pause game and wait for animation to finish
        PauseGame();
        
        //Reset Animation
        countdownAnimation.SetTrigger("Restart Animation");
    }

    public void PauseGame(){
        timerController.Playing(false);
        ropeManager.Pause();
    }

    public void UpdateScore(string winner){
        if(winner=="orange"){
         scoreManager.AddPointToOrange();   
        }
        if(winner=="blue"){
         scoreManager.AddPointToBlue();   
        }
    }

}
