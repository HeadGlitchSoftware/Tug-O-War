using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    //[Header("Scene Components")]
    [SerializeField]
    private TimerController timerController;
    [SerializeField]
    private RopeManager ropeManager;

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
        timerController.ResetTimer();
        ropeManager.Reset();
    }
}
