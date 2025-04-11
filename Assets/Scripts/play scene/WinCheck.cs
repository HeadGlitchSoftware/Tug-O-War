using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    public BoxCollider2D flagCollider;
    public BoxCollider2D orangeWinCollider;
    public BoxCollider2D blueWinCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered!");

        if (other == orangeWinCollider)
        {
            OnOrangeWin();
        }
        else if (other == blueWinCollider)
        {
            OnBlueWin();
        }
    }

    void OnOrangeWin()
    {
        Debug.Log("Orange Wins!");
        GameManager.Instance.ResetGame();
        ScoreManager.Instance.AddOrangeScore();
    }

    void OnBlueWin()
    {
        Debug.Log("Blue Wins!");
        ScoreManager.Instance.AddBlueScore();
        GameManager.Instance.ResetGame();
    }
}
