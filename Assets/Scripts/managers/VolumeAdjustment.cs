// Place this in a script like "UIButtonSFX.cs" and attach it to the same GameObject as your Button
using UnityEngine;

public class VolumeAdjustment : MonoBehaviour
{
    public void SetSFXVolume(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetSFXVolume(value);
        }
    }

        public void SetAmbientVolume(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetAmbientVolume(value);
        }
    }

        public void SetMusicVolume(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMusicVolume(value);
        }
    }
}
