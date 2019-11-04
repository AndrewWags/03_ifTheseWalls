using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : Singleton<AudioManager>
{

    public float volume = 1;
    public float musicVolume = 1f;
    public GameObject audioSourcePrefab;

    public AudioSource musicAudioSource;

    public SfxLibrary sfxLibrary;
    public AmbientAudioLibrary ambientLibrary;

    CoroutineManager.Item musicSequence = new CoroutineManager.Item();

    // Use this for initialization
    void Awake()
    {
        SfxLibrary.instance = sfxLibrary;
        AmbientAudioLibrary.instance = ambientLibrary;

        PlayMusic(ambientLibrary.level.dungeon);
    }

    public static void PlayAudio(AudioClip audioClip, float pitch = 1f)
    {
        PlayAudio(audioClip, Vector3.zero, pitch);
    }

    public static void PlayAudio(AudioClip[] audioClips, float pitch = 1f)
    {
        PlayAudio(audioClips.PickRandom(), Vector3.zero, pitch);
    }

    public static void PlayAudio(AudioClip audioClip, Vector3 location, float pitch = 1f)
    {
        if (audioClip == null) return;

        AudioSource audioSource = Instantiate(instance.audioSourcePrefab, instance.transform).GetComponent<AudioSource>();

        audioSource.transform.position = location;

        audioSource.pitch = pitch;
        audioSource.volume = instance.volume;
        audioSource.PlayOneShot(audioClip);

        if (pitch != 1f)
        {
            AudioSourceTimeScaler timeScaler = audioSource.GetComponent<AudioSourceTimeScaler>();
            if (timeScaler) timeScaler.enabled = false;
        }
    }

    public static void PlayMusic(AudioClip newTrack)
    {
        instance.musicSequence.value = instance.SwitchMusicTrack(newTrack);
    }

    IEnumerator SwitchMusicTrack(AudioClip newTrack)
    {
        float fadeDuration = 0.5f;

        float timeRemaining = fadeDuration;

        while (timeRemaining > 0f)
        {
            musicAudioSource.volume = (timeRemaining / fadeDuration) * musicVolume;
            timeRemaining -= Time.deltaTime;
            yield return null;
        }

        musicAudioSource.Stop();

        musicAudioSource.clip = newTrack;

        musicAudioSource.Play();

        float timeElapsed = 0f;

        while (timeElapsed < fadeDuration)
        {
            musicAudioSource.volume = (timeElapsed / fadeDuration) * musicVolume;
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        musicAudioSource.volume = musicVolume;

        while (musicAudioSource.isPlaying) yield return null;
    }
}