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
            GameManager.Instance.OnLossAction();
        }
        else if (other == blueWinCollider)
        {
            GameManager.Instance.OnWinAction();
        }
    }

    public void OnTimeOut(){
        if (gameObject.transform.position.y > 0){
            GameManager.Instance.OnLossAction();
        }
        else if (gameObject.transform.position.y < 0){
            GameManager.Instance.OnWinAction();
        }
    }
}
