using UnityEngine;
using System.Collections.Generic;
using System;

public class AudioManager : MonoBehaviour
{
    // Singleton pattern
    public static AudioManager Instance;

    // Audio Sources for background music, sound effects, and ambient sounds
    private AudioSource musicSource;
    private AudioSource sfxSource;
    private AudioSource ambientSource;

    // Volume controls (can be adjusted from the Inspector)
    [Range(0f, 1f)] public float musicVolume = 0.5f;
    [Range(0f, 1f)] public float sfxVolume = 0.5f;
    [Range(0f, 1f)] public float ambientVolume = 0.5f;

    // Music, SFX, and Ambient Clips (can be assigned from the Inspector)
    public AudioClip[] musicClips;
    public AudioClip[] sfxClips; 
    public AudioClip[] ambientClips;

    public string[] sfxClipNames; 
    public string[] musicClipNames;
    public string[] ambientClipNames;

    public String defaultMusicClip = "Default Music";
    public String defaultAmbientClip = "Ambient Sound";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeAudioManager()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("AudioManager(Auto)");
            go.AddComponent<AudioManager>();
        }
    }

    private void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevents the AudioManager from being destroyed on scene load
        }
        else
        {
            Destroy(gameObject);
        }

        // Get the AudioSources (can be attached in the inspector or created in script)
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();
        ambientSource = gameObject.AddComponent<AudioSource>();

        // Set default settings for AudioSources
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        sfxSource.loop = false;
        sfxSource.volume = sfxVolume;
        ambientSource.loop = true;
        ambientSource.volume = ambientVolume;

        // Automatically collect audio clips from the Resources/Audio folder
        CollectAudioClips("Audio");

        // Play the default music and ambient sound on start
        if (defaultMusicClip != null)
        {
            PlayMusic(defaultMusicClip);
        }
        else
        {
            Debug.LogWarning("Default music clip is not assigned.");
        }

        if (defaultAmbientClip != null)
        {
            PlayAmbient(defaultAmbientClip);
        }
        else
        {
            Debug.LogWarning("Default ambient clip is not assigned.");
        }
    }

    // Play ambient sound by file name
    public void PlayMusic(string clipName)
    {
        int index = GetClipIndexByName(musicClipNames, clipName);

        if (index != -1)
        {
            musicSource.clip = musicClips[index];
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Music sound with name '" + clipName + "' not found.");
        }
    }

    // Stop the background music
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Play a sound effect by file name
    public void PlaySFX(string clipName)
    {
        int index = GetClipIndexByName(sfxClipNames, clipName);

        if (index != -1)
        {
            sfxSource.PlayOneShot(sfxClips[index]);
        }
        else
        {
            Debug.LogWarning("Sound effect with name '" + clipName + "' not found.");
        }
    }

    // Play ambient sound by file name
    public void PlayAmbient(string clipName)
    {
        int index = GetClipIndexByName(ambientClipNames, clipName);

        if (index != -1)
        {
            ambientSource.clip = ambientClips[index];
            ambientSource.Play();
        }
        else
        {
            Debug.LogWarning("Ambient sound with name '" + clipName + "' not found.");
        }
    }

    // Stop ambient sound
    public void StopAmbient()
    {
        ambientSource.Stop();
    }

    // Helper method to get the clip index by name
    private int GetClipIndexByName(string[] clipNames, string clipName)
    {
        for (int i = 0; i < clipNames.Length; i++)
        {
            if (clipNames[i] == clipName)
            {
                return i;
            }
        }

        return -1; // Return -1 if clip is not found
    }

    // Automatically collects audio clips from the given folder in Resources
    private void CollectAudioClips(string folderPath)
    {
        // Load all audio clips from the specified folder
        AudioClip[] allClips = Resources.LoadAll<AudioClip>(folderPath);
        
        // Create lists to hold the clips and their corresponding names
        List<AudioClip> musicList = new List<AudioClip>();
        List<AudioClip> sfxList = new List<AudioClip>();
        List<AudioClip> ambientList = new List<AudioClip>();
        List<string> musicNames = new List<string>();
        List<string> sfxNames = new List<string>();
        List<string> ambientNames = new List<string>();

        foreach (AudioClip clip in allClips)
        {
            // Add clips to appropriate lists (music vs sound effects vs ambient sounds)
            if (clip.name.Contains("Music"))
            {
                musicList.Add(clip);
                musicNames.Add(clip.name);
            }
            else if (clip.name.Contains("Ambient"))
            {
                ambientList.Add(clip);
                ambientNames.Add(clip.name);
            }
            else
            {
                sfxList.Add(clip);
                sfxNames.Add(clip.name);
            }
        }

        // Convert lists to arrays for use in the script
        musicClips = musicList.ToArray();
        sfxClips = sfxList.ToArray();
        ambientClips = ambientList.ToArray();
        musicClipNames = musicNames.ToArray();
        sfxClipNames = sfxNames.ToArray();
        ambientClipNames = ambientNames.ToArray();
    }

    // Set music volume (between 0 and 1)
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        musicSource.volume = musicVolume;
    }

    // Set sound effect volume (between 0 and 1)
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        sfxSource.volume = sfxVolume;
    }

    // Set ambient sound volume (between 0 and 1)
    public void SetAmbientVolume(float volume)
    {
        ambientVolume = Mathf.Clamp01(volume);
        ambientSource.volume = ambientVolume;
    }
}
