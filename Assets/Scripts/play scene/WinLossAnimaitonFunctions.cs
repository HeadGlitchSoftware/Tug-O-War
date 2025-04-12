using UnityEngine;

public class WinLossAnimationFunctions : MonoBehaviour
{
    public void PlaySound(string soundName){
        AudioManager.Instance.PlaySFX(soundName);
    }

    public void LoadScene(string sceneName){
        SimpleSceneManager.Instance.LoadScene(sceneName);
    }
}