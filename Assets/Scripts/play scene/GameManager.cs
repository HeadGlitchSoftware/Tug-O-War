using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [SerializeField] private TimerController timerController;

    [SerializeField] private RopeManager ropeManager;

    [SerializeField] private Animator countdownAnimation;
    [SerializeField] private Animator winLossAnimation;

    private bool playing = false;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }
    public void OnWinAction()
    {
        ScoreManager.Instance.AddBlueScore();
        winLossAnimation.SetTrigger("OnWin");
        FreezeGame(true);
        playing = false;
    }

    public void OnLossAction(){
        ScoreManager.Instance.AddOrangeScore();
        winLossAnimation.SetTrigger("OnLose");
        FreezeGame(true);
        playing = false;
    }

    public void StartGame(){
        playing = true;
        ResumeGame();
    }

    public void ResetGame()
    {
        playing = false;
        
        //Reset scene elements
        timerController.ResetTimer();
        ropeManager.Reset();

        FreezeGame(true);

        //Reset Animation
        countdownAnimation.SetTrigger("Restart Animation");
    }


    public void PauseGame(){
        countdownAnimation.enabled = false;
        
        if (playing){
            FreezeGame(true);
        }
    }

    public void ResumeGame()
    {
        countdownAnimation.enabled = true;

        if (playing){
            FreezeGame(false);
        }
    }

    private void FreezeGame(bool freeze){
        if (freeze){
            timerController.Playing(false);
            ropeManager.Pause();
        }
        else if (!freeze){
            timerController.Playing(true);
            ropeManager.Play();
        }
    }
}
