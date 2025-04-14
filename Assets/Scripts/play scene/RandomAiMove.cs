using System.Collections.Generic;
using UnityEngine;

public class RandomAIMove : MonoBehaviour
{
    [SerializeField] private float moveDistance = 0.5f; // The distance to move the object each time
    [SerializeField] private float minInterval = 1f;  // Minimum time interval between movements
    [SerializeField] private float maxInterval = 3f;  // Maximum time interval between movements
    [SerializeField] private string soundEffectName;

    private float nextMoveTime;

    private void Start()
    {
        SetDifficultyValues(DifficultySettings.Difficulty);
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

    private void SetDifficultyValues(int difficulty)
    {
        switch (difficulty)
        {
            case 0: // Easy
                minInterval = 0.1f;
                maxInterval = 0.5f;
                break;
            case 1: // Normal
                minInterval = 0.1f;
                maxInterval = 0.25f;
                break;
            case 2: // Hard
                minInterval = 0.1f;
                maxInterval = 0.2f;
                break;
            case 3:
                minInterval = 0.1f;
                maxInterval = 0.15f;
                break;
            default:
                minInterval = 0.1f;
                maxInterval = 0.25f;
                break;
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
