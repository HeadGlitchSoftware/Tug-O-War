using UnityEngine;
using UnityEngine.UI;

public class VolumeAdjustment : MonoBehaviour
{
    [SerializeField] Slider SliderSFX;
    [SerializeField] Slider SliderAmbient;
    [SerializeField] Slider SliderMusic;

    private void Start(){
        InitializeSliders();
    }

    private void InitializeSliders(){
        if (SliderSFX != null){
            SliderSFX.value = AudioManager.Instance.sfxVolume;
        }
        if (SliderAmbient != null){
            SliderAmbient.value = AudioManager.Instance.ambientVolume;
        }
        if (SliderMusic != null){
            SliderMusic.value = AudioManager.Instance.musicVolume;
        }
    }

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
