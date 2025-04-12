using UnityEngine;

public class MoveOnSpace : MonoBehaviour
{
    // Speed at which the object will move on the Y-axis
    [SerializeField] private float moveDistance = 0.5f;
    [SerializeField] private string soundEffectName;

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound();
            TranslateObject();
        }
    }

    void TranslateObject(){
        // Move the GameObject along the Y-axis by the specified moveSpeed
        transform.Translate(0, -moveDistance, 0);
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
