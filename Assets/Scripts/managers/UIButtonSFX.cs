// Place this in a script like "UIButtonSFX.cs" and attach it to the same GameObject as your Button
using UnityEngine;

public class UIButtonSFX : MonoBehaviour
{
    [SerializeField]
    public string sfxName;

    public void PlayButtonSound()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(sfxName);
        }
    }
}
