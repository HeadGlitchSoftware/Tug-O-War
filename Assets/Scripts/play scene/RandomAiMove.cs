using UnityEngine;

public class RandomAI_Move : MonoBehaviour
{
    [SerializeField]
    public float moveDistance = 0.5f; // The distance to move the object each time
    #region 
    [SerializeField]
    public float minInterval = 1f;  // Minimum time interval between movements
    [SerializeField]
    public float maxInterval = 3f;  // Maximum time interval between movements
    #endregion
    [SerializeField]
    private string soundEffectName;

    private float nextMoveTime;

    private void Start()
    {
        // Start the first movement
        SetNextMoveTime();
    }

    private void Update()
    {
        // Check if it's time to move the object
        if (Time.time >= nextMoveTime)
        {
            //Play sound effect
            PlaySound();
            // Move the object
            MoveObject();
            // Set the next time the object will move
            SetNextMoveTime();
        }
    }

    private void SetNextMoveTime()
    {
        // Randomly choose a time between the minInterval and maxInterval
        nextMoveTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    private void MoveObject()
    {
        transform.Translate(0, moveDistance, 0);
    }

    void PlaySound(){
        // Check if a sound effect is applied
        if (soundEffectName != null){
            try{
            AudioManager.Instance.PlaySFX(soundEffectName);
            }
            catch{
                Debug.LogWarning("Unable to play Sound Effect!");
            }
        }
    }
}
