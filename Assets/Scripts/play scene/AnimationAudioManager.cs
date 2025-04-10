using UnityEngine;

public class AnimationAudioManager : MonoBehaviour
{
    private AudioSource[] audioSources;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSources = GetComponentsInChildren<AudioSource>();
    }

    public void PlayAnimatorSound(string clipName)
    {
        foreach (var source in audioSources)
        {
            if (source.clip != null && source.clip.name == clipName)
            {
                source.Play();
                return;
            }
        }

        Debug.LogWarning($"Clip '{clipName}' not found on {gameObject.name}");
    }

    public void PauseAll()
    {
        animator.enabled = false;

        foreach (var source in audioSources)
        {
            if (source.isPlaying)
            {
                source.Pause();
            }
        }
    }

    public void ResumeAll()
    {
        animator.enabled = true;

        foreach (var source in audioSources)
        {
            if (source.clip != null && source.time > 0f)
            {
                source.UnPause();
            }
        }
    }
}
