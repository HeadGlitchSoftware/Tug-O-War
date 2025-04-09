using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownAnimationFunctions : MonoBehaviour
{
    public void PlaySound(string soundEffectName){
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