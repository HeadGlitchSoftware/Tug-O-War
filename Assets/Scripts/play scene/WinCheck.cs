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
        GameManager.Instance.UpdateScore("orange");
        GameManager.Instance.ResetGame();
    }

    void OnBlueWin()
    {
        Debug.Log("Blue Wins!");
        GameManager.Instance.UpdateScore("blue");
        GameManager.Instance.ResetGame();
    }
}
