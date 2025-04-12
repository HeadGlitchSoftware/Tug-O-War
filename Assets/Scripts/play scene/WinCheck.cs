using UnityEngine;

public class WinCheck : MonoBehaviour
{
    [SerializeField] private BoxCollider2D flagCollider;
    [SerializeField] private BoxCollider2D orangeWinCollider;
    [SerializeField] private BoxCollider2D blueWinCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
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
